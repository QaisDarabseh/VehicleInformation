 Project Overview


# Web application built using ASP.NET Core 8 that allows users to:
1-Select car make
2-Enter manufacture year
3-View available vehicle types
4-View models based on selected criteria
5-Data is retrieved from the NHTSA Vehicle API.

# Technologies Used:
1-ASP.NET Core 8 (MVC)
2-jQuery
3-Docker
4-AWS EC2 (Free Tier)

# APIs Used:
1-Get All Makes
2-Get Vehicle Types for Make
3-Get Models by Make and Year

# Run Locally Using Docker:
Prerequisites:
Docker installed

Steps:
docker build -t vehicle-app .
docker run -d -p 80:8080 vehicle-app
Then open:
http://localhost

# AWS Deployment
The application is deployed on AWS EC2 (Free Tier) and publicly accessible.
Live URL: http://13.60.97.23/

# GitHub Repository
https://github.com/QaisDarabseh/VehicleInformation


GitHub Repo:

https://github.com/<your-username>/<repo-name>
