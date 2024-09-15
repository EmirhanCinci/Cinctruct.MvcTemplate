<h1>Cinctruct MVC Template</h1>

<h3 align="center">
    <img src="https://readme-typing-svg.herokuapp.com/?font=Righteous&size=35&center=true&vCenter=true&width=500&height=70&duration=4000&lines=Streamline+Your;+ASP.NET+Core+MVC+Projects;+with+Our+Robust;+and+Flexible+Template.;" />
</h3>

<h2>Overview</h2>

<p>
This ASP.NET Core MVC template provides a robust foundation for building modern web applications. It includes essential components such as HTTP API service handling, session management, custom middleware for cache control and status code handling, and more. Designed for scalability and maintainability, this template streamlines development processes and enhances application performance.
</p>

<br/>

<h2>Features</h2>

* **`HTTP API Service:`** Simplifies communication with external services using **`IHttpApiService`** and **`HttpApiService`** for various HTTP methods.
* **`Session Management:`** Handles user session data efficiently with **`SessionExtensions`** and **`SessionFilter`**.
* **`Custom Middleware:`** Includes **`CacheControlHandler`** for managing cache policies and **`StatusCodeHandler`** for custom error handling and redirection.
* **`Flexible Base Controller:`** Provides a base controller with built-in session validation and redirection logic.

<br/>

<h2>Status Code Pages</h2>

The Status Code Pages provide customized responses for different HTTP status codes. This feature enhances user experience by directing users to appropriate pages based on the response status from the server. Here are the available status code pages:

1. **UnAuthorize Page:** Displays when users attempt to access resources they are not authorized to view. This page informs users of authorization issues and directs them to log in or contact support.

<img src="Assets/401.png" height=500>

2. **NotFound Page:** Shows when a requested resource cannot be found on the server. It provides a friendly message and suggestions for navigating back to the main site or searching for the desired content.

<img src="Assets/404.png" height=500>

3. **Error Page:** Appears for general server errors or unexpected issues. This page informs users of the problem and provides guidance on how to proceed or contact support.

<img src="Assets/500.png" height=500>

<h2>Usage</h2>

1. **`Setup:`** Add the template to your ASP.NET Core MVC project by installing the necessary NuGet packages and configuring services in **`Program.cs`**.
2. **`API Integration:`** Utilize **`HttpApiService`** for making API calls. Configure service URLs in **`appsettings`**.json and handle responses in your controllers.
3. **`Session Management:`** Use **`SessionExtensions`** for session data storage and retrieval. Apply **`SessionFilter`** to protect your routes from unauthorized access.
4. **`Middleware:`** Integrate **`CacheControlHandler`** and **`StatusCodeHandler`** in your middleware pipeline to manage cache policies and handle errors gracefully.

<br/>

<h2 align="center">⚒️ Languages-Frameworks ⚒️</h2>

<br/>

<div align="center">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/html5/html5-original.svg" height="55" alt="html5 logo" />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/css3/css3-original.svg" height="55" alt="css3 logo" />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/bootstrap/bootstrap-plain.svg" height="55" alt="bootstrap logo" />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/javascript/javascript-original.svg" height="55" alt="javascript logo" />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/jquery/jquery-original.svg" height="55" alt="jquery logo" />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" height="55" alt="csharp logo" />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-plain-wordmark.svg" height="55" alt="dot-net logo" />
</div>