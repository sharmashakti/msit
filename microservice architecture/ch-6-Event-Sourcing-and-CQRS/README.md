# Ch-6 Event Sourcing and CQRS
## Architecture of Examples done in this Chapter
![image](https://user-images.githubusercontent.com/14904879/120880267-fb0cc480-c5e6-11eb-80e8-ad440ade09c9.png)

## 1. PreRequisites for Running the Examples
1. RabbitMQ Server (Docker Container)
   > docker run --rm -it --hostname my-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management
2. Redish Server (Docker Container)
   > docker run --name some-redis --rm -p 6379:6379/tcp -d redis

## 2. Applications (Examples)
1. Location Reporter   (http://localhost:9090)
   1. Receives a Request to store Location of a Member
   2. Gets The Team ID of the Member
   3. Creates a new Location Event Message and Psushed to Rabbit MQ server
3. Event Processor  (http://localhost:9092)
   1.Reads the Location Event Message from Rabbit MQ Server
   2.Stores in the Location in Redis Cache Server
   3.Checks if there is Already a team member in same location
   4.If found then raise another Rabbit
5. Teams Service (http://localhost:5000)
6. PrximityDetector (http://localhost:9091)
