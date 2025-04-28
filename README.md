# WebAPI

Our project works in the following way:
We have two repositories: 
  1) WebAPI *(this one)*: runs the local database for your machine, so imagine this as a hosted server somewhere (except you run it locally), which you can make http requests to. An example would be you're in the app, you need the list of users to display it on the screen. How do you do this? You call a method in the repository which makes an http request to this server that is hosted somewhere (again, you are running it locally, separate from the actual app. For the homework purposes it's not hosted), and that's how you retrieve the users. It replaces querying the SQL Server database with querying this API that you run as a separate project.
  2) Client repo (where the actual app is): *soon to be documented*
        

```
.
├── 📜 LICENSE                                      # License file for the project
├── 📂 Pages
│   ├── ❗ Error.cshtml                             # Razor page to display error details
│   ├── ❗ Error.cshtml.cs                          # Code-behind for error page handling
│   ├── 🏠 Index.cshtml                             # Razor page for the home/index page
│   ├── 🏠 Index.cshtml.cs                          # Code-behind for index page logic
│   ├── 🔒 Privacy.cshtml                           # Razor page for privacy policy
│   ├── 🔒 Privacy.cshtml.cs                        # Code-behind for privacy page logic
│   ├── 📂 Shared
│   │   ├── 🧩 _Layout.cshtml                       # Common layout (header/footer) for pages
│   │   ├── 🎨 _Layout.cshtml.css                   # CSS for shared layout styling
│   │   └── ✅ _ValidationScriptsPartial.cshtml     # Partial view for client-side validation scripts
│   ├── 🧰 _ViewImports.cshtml                      # Import namespaces and tag helpers globally
│   └── 🚀 _ViewStart.cshtml                        # Set the layout for Razor pages
├── 🚀 Program.cs                                   # Entry point: sets up and runs the web app
├── 📂 Properties
│   └── 🎛️ launchSettings.json                      # Defines profiles for local launch (e.g., ports, environment)
├── 📖 README.md                                    # Project documentation and instructions
├── 📦 WebApi.csproj                                # C# project file with references and build settings
├── 🧩 WebApi.sln                                   # Solution file for the project
├── ⚙️ appsettings.Development.json                 # App settings specific to Development environment
├── ⚙️ appsettings.json                             # Main app configuration (connection strings, logging, etc.)
└── 🌐 wwwroot                                      # Static files like CSS, JS, images (not C#-related)
```
