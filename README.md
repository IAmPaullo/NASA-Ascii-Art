# NASA Astronomy Picture of the Day to ASCII Art Generator
![11](https://github.com/IAmPaullo/NASA-Ascii-Art/assets/39301693/b39d015c-f69a-4a64-a4c5-a86d867dce54)

I've always been a fan of ASCII art. From old forums to my personal Steam page, I find it amazing how people can be creative with these artworks.

This application generates ASCII art representations of images. It utilizes the NASA Astronomy Picture of the Day (APOD) API to download and process images, converting them into pixelated ASCII art. The application offers multiple output options, including text files, image files, and direct printing capabilities.
It was created with the intention of learning how ASCII art works and how it's created.

## Features

Image Download: Retrieves images from the NASA APOD API.
Image Processing: Converts images into ASCII art using pixel-based conversion techniques.
Progress Monitoring: Provides real-time progress updates during image download and processing.

## Requirements

Operating System: Windows, macOS, or Linux
Runtime: .NET Framework 4.7 or later
## Installation

Clone the repository to your local machine.
Open the project in Visual Studio or your preferred IDE.
Ensure the .NET Framework 4.7 or later is installed.
Build the project.
## Usage

Run the application from the project directory.
The application will prompt you for the destination folder to save the generated ASCII art.
The application will download an image from the NASA APOD API, process it into ASCII art, and save it to the specified folder.
The application will display the image title to the console.
## Options

Specify a custom image URL instead of using the NASA APOD API: Edit the ImageDownload.cs file and modify the imgURL variable before running the application.
## Contributing

I welcome contributions to improve this project. Please fork the repository, make your changes, and create a pull request.

## License

This project is licensed under the MIT License.
