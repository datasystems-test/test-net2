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
    stage('XDP Core Services Build') {
            steps{
              bat  '''cd "C:\\Users\\AF-0094\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\PIPeline .net\\"
              dotnet build CRUD-NETCore-TDD.sln'''
              echo 'Core Services Build Done' 
            }
		}

     stage('XDS Delivery Service Unit Test') {
                steps{
                bat  '''cd "C:\\Users\\AF-0094\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\PIPeline .net\\CRUD-NETCore-TDD.Test\\"
                dotnet test -v n --no-build CRUD-NETCore-TDD.Test.csproj --logger \\"trx;LogFileName=unit_tests.xml\\"'''
                echo 'XDS Service Unit Test Done'  
            }
		}
	stage('Integration') {
			steps{
			 junit '"\\CRUD-NETCore-TDD.Test\\TestResults\\unit_tests.xml\\"'
			
			
			}
		}
    stage('Publish'){
      steps{
	   bat  '''cd "C:\\Users\\AF-0094\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\PIPeline .net\\"
              dotnet publish CRUD-NETCore-TDD.sln'''
              echo 'Core Services Build Done' 
   
      }
    }		

  }

}

