# MyResumeSite - Simple Todos API Integration

## API Used
**JSONPlaceholder Todos API**: `https://jsonplaceholder.typicode.com/todos`

**Why this API**: The JSONPlaceholder Todos API is a reliable, well-documented REST API that provides consistent JSON responses. It's perfect for demonstrating basic API consumption concepts with simple HTTP requests and JSON deserialization.

## Simple Code Structure

### TodoItem Class:
A basic model class with simple properties:
- **`UserId`** (int): User who owns the todo item
- **`Id`** (int): Unique identifier for each todo item  
- **`Title`** (string): Description of the todo task
- **`Completed`** (bool): Completion status (true/false)

### ApiList Page:
- Simple page model that fetches data from API service
- Displays first 10 todo items in a basic table
- Clean, easy-to-understand code structure

### Features:
- Basic API data fetching
- Simple table display
- Easy to read and understand code
- No complex error handling or loading states
