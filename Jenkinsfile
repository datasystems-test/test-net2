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

    stage('Descarga proyecto GitHub') {
      steps {
        git credentialsId: '8b729564-ae78-40b1-b5c9-4545949c1485', url: 'https://github.com/datasystems-test/test-net2.git', branch: 'main'
      }
    }
    stage('XDP Core Services Build') {
            steps{
			echo '**********************************************************************************'  
	        echo '*************               XDP Core Services Buil                   *************'	
	        echo '**********************************************************************************' 
              bat  '''cd "C:\\Users\\AF-0094\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\PIPeline .net\\"
              dotnet build CRUD-NETCore-TDD.sln'''
              echo 'Core Services Build Done' 
            }
		}

     stage('XDS Delivery Service Unit Test') {
                steps{
			echo '**********************************************************************************'  
	        echo '*************             XDS Delivery Service Unit Test             *************'	
	        echo '**********************************************************************************' 	
                bat  '''cd "C:\\Users\\AF-0094\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\PIPeline .net\\CRUD-NETCore-TDD.Test\\"
                dotnet test -v n --no-build CRUD-NETCore-TDD.Test.csproj --logger \\"trx;LogFileName=TestResult.xml\\"'''
                echo 'XDS Service Unit Test Done'
			
            }
		}

    stage('Publish'){
      steps{
			echo '**********************************************************************************'  
	        echo '*************             Core Services Build Done                   *************'	
	        echo '**********************************************************************************' 		     		
	   bat  '''cd "C:\\Users\\AF-0094\\AppData\\Local\\Jenkins\\.jenkins\\workspace\\PIPeline .net\\"
              dotnet publish CRUD-NETCore-TDD.sln'''
	        echo '**********************************************************************************' 
   
      }
    }

  }

}

post { 
    always {
         nunit testResultsPattern: 'TestResult.xml'
    }
}


