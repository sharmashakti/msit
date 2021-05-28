
In windows 10 (Windows 10 64-bit: Home, Pro, Enterprise, or Education, version 1903 (Build 18362 or higher)), is better to enable WSL2 for Docker installation.
https://www.omgubuntu.co.uk/how-to-install-wsl2-on-windows-10
<br>
<br>
Install Docker Desktop on Windows | Docker Documentation 
https://docs.docker.com/docker-for-windows/install/ 

<br>
Docker installation and setup in Linux is very smoother than Windows, follow below link <br>
https://docs.docker.com/engine/install/ubuntu/
<br>

To Test whether your Docker is installed and setup properly <br>
Run below Commands: <br>
docker version <br>
docker info <Br>

<br>
Optioanlly, you can pull and run the "getting-started" docker image from the docker hub
Run below command: <br>
docker run -d -p 80:80 docker/getting-started <br>
Now navigate to the borwser http://localhost  <br>
<br>
<br>

<h2> Now, your Docker is installed and configured correctly. <br>
Follow below steps to containerize our First Asp.Net Core Web Api project </h2> <br>
1. Open Command Prompt and Navigate to ch-2-delivering-continously folder <br>
2. Run Cmd: docker build -t first-aspnetcore-webapi:1.0 .   <br>
3. Run below command to see if image created successfully.   <br>
    docker images <br>
    You should see a image with name first-aspnetcore-webapi
4. Run below command the docker image into Container <br>
   docker run --rm -p 80:80/tcp first-aspnetcore-webapi:1.0
5. Browed http:localhost in your browser. <br>

You should see hello world!

<br>
<br>
Important dockers Commands <br>
docker version 
docker build   (Builds a new image for a Dockerfile)
docker image ls  (List all images available locally)
docker run {{params}} (Runs a new container from a docker image)
docker ps  (list all running containers)
docker stop {{container id}}
docker kill {{container id}} (kills the running container)

Learning Resources:
Docker Command 
https://docs.docker.com/engine/reference/commandline/docker/ 