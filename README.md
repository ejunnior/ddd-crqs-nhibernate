
1. Install Docker Desktop for Mac or Docker CE for Windows from https://docker.com.
1. Set the environment variables in your command window.

      `export APP_ENV=development`
      
      `export DOCKER_REG=ejunnior`

      NOTE: For the Windows DOS command shell use `set` instead of `export`. For Windows Powershell use `$env:APP_ENV = "value"`.

1. Run `docker-compose -f docker-compose.yml -f docker-compose-dev.yml up -d`
1. Visit http://localhost:20001 in a browser
