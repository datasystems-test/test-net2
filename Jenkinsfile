pipeline {
  
  agent any
   environment {
        dotnet ='C:\\Program Files\\dotnet\\'
        }

  stages {
    stage ('Clean workspace') {
      steps {
        cleanWs()
      }
    }

    stage('Checkout') {
      steps {
        git credentialsId: '8b729564-ae78-40b1-b5c9-4545949c1485', url: 'https://github.com/datasystems-test/test-net2.git', branch: 'main'
      }
    }

    stage('Restore packages') {
      steps {
        bat "dotnet restore ${workspace}\\CRUD-NETCore-TDD.sln"
      }
    }

    stage('Clean'){
      steps{
        bat "dotnet clean ${workspace}\\CRUD-NETCore-TDD.sln"
      }
    }

    stage('Build'){
      steps{ 
        bat "dotnet build ${workspace}\\CRUD-NETCore-TDD.sln--configuration Release"
      }
    }

    stage('Publish'){
      steps{
       bat "dotnet publish ${workspace}\\CRUD-NETCore-TDD.sln -c Release"
      }
    }


  }

}

