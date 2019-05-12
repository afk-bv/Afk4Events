pipeline {
    agent any
    
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        
        stage('Restore') {
            steps {
                sh "dotnet restore"
            }
        }
        
        stage('Clean') {
            steps {
                sh 'dotnet clean'
            }
        }
        
        stage('Build') {
            steps {
                sh 'pwsh ./Afk4Events.TelegramBot/build.ps1'
            }
        }
    }
}
