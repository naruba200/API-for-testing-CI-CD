pipeline {
    agent any

    stages {
        stage('Clone') {
            steps {
                echo 'Cloning source code...'
                git branch: 'main', url: 'https://github.com/naruba200/API-for-testing-CI-CD.git'
            }
        }

        stage('Restore Packages') {
            steps {
                echo 'Restoring NuGet packages...'
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                echo 'Building project...'
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Test') {
            steps {
                echo 'Running tests...'
                bat 'dotnet test --no-build --verbosity normal'
            }
        }

        stage('Publish to Folder') {
            steps {
                echo 'Publishing project to ./publish folder...'
                bat 'dotnet publish -c Release -o ./publish'
            }
        }

        stage('Copy to IIS Folder') {
            steps {
                echo 'Copying published files to IIS folder...'
                bat '''
                if exist "C:\\wwwroot\\myproject" (
                    echo Deleting old files...
                    rmdir /S /Q "C:\\wwwroot\\myproject"
                )
                mkdir "C:\\wwwroot\\myproject"
                xcopy "%WORKSPACE%\\publish" "C:\\wwwroot\\myproject" /E /Y /I /R
                '''
            }
        }

        stage('Deploy to IIS') {
            steps {
                echo 'Deploying to IIS...'
                powershell '''
                    Import-Module WebAdministration
                    $siteName = "MySite"
                    $sitePath = "C:\\wwwroot\\myproject"
                    $port = 81

                    if (!(Test-Path "IIS:\\Sites\\$siteName")) {
                        New-Website -Name $siteName -Port $port -PhysicalPath $sitePath -Force
                    } else {
                        Set-ItemProperty "IIS:\\Sites\\$siteName" -Name physicalPath -Value $sitePath
                        Restart-WebItem "IIS:\\Sites\\$siteName"
                    }
                '''
            }
        }
    }

    post {
        success {
            echo '✅ Deployment completed successfully!'
        }
        failure {
            echo '❌ Build or deployment failed!'
        }
    }
}
