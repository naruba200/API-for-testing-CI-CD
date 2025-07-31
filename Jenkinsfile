pipeline {
    agent any

    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = "1"
        DOTNET_SKIP_FIRST_TIME_EXPERIENCE = "1"
    }

    stages {
        stage('Checkout') {
            steps {
                git 'https://github.com/yourusername/SimpleApi.git'
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release'
            }
        }

        stage('Test') {
            steps {
                // Uncomment this if you have tests
                // sh 'dotnet test'
                echo 'No tests yet - skipping test stage'
            }
        }

        stage('Publish') {
            steps {
                sh 'dotnet publish -c Release -o ./publish'
            }
        }

        stage('Deploy') {
            steps {
                echo 'You can add a custom deployment script here (e.g., copy to IIS or Docker run)'
            }
        }
    }

    post {
        success {
            echo 'Build and publish completed successfully!'
        }
        failure {
            echo 'Something went wrong with the build.'
        }
    }
}
