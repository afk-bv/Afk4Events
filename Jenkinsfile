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
                sh "pwsh ./Afk4Events.TelegramBot/build.ps1 -tag ${env.BRANCH_NAME}"
            }
        }
        
        stage('Deploy') {
            when { 
              anyOf {
                branch 'master' 
                branch 'dev'
              }
            }
            
            steps {
                sh "pwsh ./Afk4Events.TelegramBot/deploy.ps1 -tag ${env.BRANCH_NAME}"
            }
        }
    }
}
