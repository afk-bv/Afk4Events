pipeline {
    agent any
    
    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }
        
        stage('Build') {
            steps {
                sh 'pwsh ./Afk4Events.TelegramBot/build.ps1'
            }
        }
        
        stage('Deploy') {
            when { 
              branch 'master'
            }
            
            steps {
                sh 'pwsh ./Afk4Events.TelegramBot/deploy.ps1          
            }
        }
    }
}
