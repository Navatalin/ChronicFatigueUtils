# Chronic Fatigue Utils

[![Publish Docker Image](https://github.com/Navatalin/ChronicFatigueUtils/actions/workflows/docker-image.yml/badge.svg?branch=main)](https://github.com/Navatalin/ChronicFatigueUtils/actions/workflows/docker-image.yml)

This application is a set of small utlities that are aimed to assist people with chronic fatigue.

The current utility is a simple tracking page where a user can input a task, how long it took them, how they felt after and if they were able to recover from that task.

This application is intended to be run as a docker container with a MongoDB backend for data persistance.

Dockerfile is written to run on ARM64 hardware (Currently k3s running on a raspberry pi 4)

## Configuration
The application uses Environmental Variables to override appsettings.json

The following should be set to provide credentials for database connection:

CFUTILS_TaskDatabaseSettings__DBUSER
CFUTILS_TaskDatabaseSettings__DBPASS

The server port and hostname can also be replaced using the following:

CFUTILS_TaskDatabaseSettings__Server
CFUTILS_TaskDatabaseSettings__ServerPort

## UI Design and Decisions
The UI for the Task Tracker has been designed to be very simple but also save all changes as soon as they are made. 
The driver behind this is that when the user is very tired they might forget to hit a save button, so the application assumes that and saves changes as they happen.
Another choice is to have all fields modifiable, this allows for the user to change details freely.
