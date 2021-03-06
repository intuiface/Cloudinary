# Cloudinary

This project contains Cloudinary Interface Asset for Intuiface Player & Intuiface Composer.

The purpose of this .NET Interface Asset is to enable an Intuiface experience to upload an image during runtime to a cloud service. The image URL can then be used either combined with a [QR Code Encoder](https://support.intuiface.com/hc/en-us/articles/360007179832-Interface-Asset-QR-Code) or sent in an email body with the [Share via Email](https://support.intuiface.com/hc/en-us/articles/360007430911-Interface-Asset-Share-via-Email) Interface Assets. 

# Prerequisite: Cloudinary account

[Cloudinary](http://cloudinary.com/) has a free version which will let you host a certain amount of images. To use our Interface Asset, you **must create your own account** on their website. You will then be able to copy & paste the following from their dashboard to your Interface Asset in Composer: 

* Cloud name
* API key
* API secret

![Cloudinary Dashboard](Resources/cloudinary-dashboard.jpg)

In Composer: 

![Cloudinary IA Properties](Resources/Cloudinary-IA-properties.jpg)


# How to build this project?

**PREREQUISITES**: you must have Visual Studio 2013 and .NET 4 installed.

The code language for Phidgets Interface Assets is C#.

To build this project, follow these steps:

* Open **ImageUploader.sln** in Visual Studio 2013 or above,
* Build the solution in **Release** mode,
* Navigate to the **bin/release** folder of the project, these are all the files to gather in a **CloudinaryImageUploader** folder before using them in Composer (see below). 

# How to use Cloudinary Image Uploader Interface Assets in Composer?

To be able to add Cloudinary Image Uploader Interface Assets in Intuiface Composer, follow these steps: 

* Copy the **CloudinaryImageUploader** folder from the **OutputAssemblies** to the path "[Drive]:\Users\\[UserName]\Documents\Intuiface\Interface Assets",
* Launch **Intuiface Composer**,
* Add an Interface Asset and when you enter "Cloudinary" in the search bar, you can see the **Cloudinary Image Uploader** Interface Asset.



See more information on our [support webpage](https://support.intuiface.com/hc/en-us/articles/360007430751-Upload-an-image-to-Cloudinary)

-----

Copyright &copy; 2016-2020 Intuiface.

Released under the **MIT License**.
