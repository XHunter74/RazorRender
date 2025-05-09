# RazorRender

**RazorRender** is a test/demo ASP.NET Core project that demonstrates two approaches for rendering Razor views and templates to HTML, suitable for scenarios like generating email content.

## Features

- **Razor View Rendering**: Renders standard Razor `.cshtml` views using the built-in ASP.NET Core view engine.
- **RazorLight Rendering**: Renders Razor templates from source strings using the [RazorLight](https://github.com/toddams/RazorLight) library, which is useful for dynamic or file-based templates outside the MVC pipeline.
- **API Endpoints**: Exposes two endpoints to render a sample email template using both approaches.
- **Swagger UI**: Integrated for easy API testing and exploration.

## Approaches Used

### 1. ASP.NET Core Razor View Engine

- Uses the default MVC view engine to render a `.cshtml` file (`Views/Emails/Welcome.cshtml`) to an HTML string.
- The `ViewRenderService` handles the rendering by creating an `ActionContext` and using `IRazorViewEngine`.
- Endpoint: `GET /api/email/razor`

### 2. RazorLight Engine

- Uses the RazorLight library to compile and render Razor templates from source strings.
- The template source is loaded from the file system (`Views/Emails/Welcome.cshtml`) and rendered with a model.
- Endpoint: `GET /api/email/razor-light`

## Project Structure

- `Controllers/EmailController.cs`: API endpoints for rendering emails.
- `Services/`: Contains services for view rendering, template loading, and RazorLight integration.
- `Views/Emails/Welcome.cshtml`: Sample Razor view/template for email.
- `Models/EmailModel.cs`: Model used for rendering the email template.

## How to Run

1. Build and run the project.
2. Open Swagger UI at `/swagger` to test the endpoints.
3. Use `/api/email/razor` to render using the built-in Razor engine.
4. Use `/api/email/razor-light` to render using RazorLight.

## Use Cases

- Email template rendering
- Comparing Razor view engine and RazorLight
- Learning about view rendering in ASP.NET Core

---

This project is for demonstration and testing purposes.
