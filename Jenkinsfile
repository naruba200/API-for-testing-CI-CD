pipeline {
    agent any

    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = "1"
        DOTNET_SKIP_FIRST_TIME_EXPERIENCE = "1"
    }

    stages {
        stage('Restore') {
            steps {
                bat 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                bat 'dotnet build --configuration Release'
            }
        }

        stage('Test') {
            steps {
                echo 'No tests yet'
            }
        }

        stage('Publish') {
            steps {
                bat 'dotnet publish -c Release -o ./publish'
            }
        }

        stage('Deploy') {
            steps {
                echo 'Add deploy steps here, e.g., copy files to IIS folder'
            }
        }
    }

    post {
        success {
            echo '✅ Build finished successfully!'
        }
        failure {
            echo '❌ Build failed!'
        }
    }
}
