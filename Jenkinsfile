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
                office365ConnectorSend message:"Started ${env.JOB_NAME} ${env.BUILD_NUMBER} (<${env.BUILD_URL}|Open>)", webhookUrl: "${env.O365_HOOK}" 
                sh "pwsh ./build.ps1 -project api -tag ${env.BRANCH_NAME}"
                sh "pwsh ./build.ps1 -project telegrambot -tag ${env.BRANCH_NAME}"
                sh "pwsh ./build.ps1 -project webclient -tag ${env.BRANCH_NAME}"
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
                sh "pwsh ./deploy.ps1 -project api -tag ${env.BRANCH_NAME}"
                sh "pwsh ./deploy.ps1 -project telegrambot -tag ${env.BRANCH_NAME}"
                sh "pwsh ./deploy.ps1 -project webclient -tag ${env.BRANCH_NAME}"
            }
        }

        stage('Report') {
           office365ConnectorSend message:"Completed ${env.JOB_NAME} ${env.BUILD_NUMBER} (<${env.BUILD_URL}|Open>)", webhookUrl: "${env.O365_HOOK}" 
        }
    }
}
