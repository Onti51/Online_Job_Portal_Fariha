# Job Finder Application

Welcome to the Job Finder application repository! This project is a web application built using React for the frontend, .NET for the backend, and PostgreSQL as the database.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Introduction

The Job Finder application is designed to help users search and apply for job openings. It provides a user-friendly interface for browsing available jobs, filtering based on criteria such as location and job type, and submitting job applications.

## Features

- **Job Search:** Users can search for job openings based on keywords, location, and other criteria.
- **Job Filtering:** Users can filter job search results based on various criteria such as location, job type, salary range, etc.
- **User Authentication:** Secure user authentication and authorization mechanisms are implemented to ensure data privacy and security.
- **Job Applications:** Users can submit job applications directly through the application, including uploading their resume and cover letter.

## Installation

To run the Job Finder application locally, follow these steps:

1. Clone this repository to your local machine using `git clone https://github.com/Asy1921/Job-Finder.git`
2. Navigate to the `ClientApp` directory and run `npm install` to install frontend dependencies.
3. Navigate to the `BAL` directory and run `dotnet restore` to restore backend dependencies.
4. Configure the PostgreSQL database by updating the DB Entities in DAL
5. Update the database connection string in the by copying your elephantSQL URL and creating a fn ConnStr.Get() in the DAL directory.
6. Run the frontend and backend servers by Generating Build and debug assets by using the .NET Generate Assets for building command (Ctrl Shift P)

## Usage

Once the application is running, you can access it through your web browser. The homepage will display job listings, and users can use the search and filtering functionality to find relevant job openings. Users can also register an account, log in, and submit job applications.

## Contributing

Contributions are welcome! If you'd like to contribute to the development of the Job Finder application, please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/yourfeature`).
3. Make your changes.
4. Commit your changes (`git commit -am 'Add new feature'`).
5. Push to the branch (`git push origin feature/yourfeature`).
6. Create a new Pull Request.

## License

This project WILL BE licensed under the [MIT License](LICENSE).
