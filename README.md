# [CLI Task Manager](https://roadmap.sh/projects/task-tracker) [26/10/2024]

This project is a command-line interface (CLI) task manager application created for learning purposes, inspired by [roadmap.sh](https://roadmap.sh). It enables users to add, read, update, and delete tasks through straightforward commands, providing a hands-on way to explore CLI application development.

## Features

- Add new tasks with a title, description, status, and priority.
- List all tasks or filter tasks by status and priority.
- Update existing tasks by ID.
- Delete tasks by ID.

## Commands

### Add a Task

Add a new task with a title, description, status, and priority.

add -t "Task Title" -d "Task Description" -s `<status>` -pr `<priority>`

- `-t`: Title of the task (required)
- `-d`: Description of the task (optional)
- `-s`: Status of the task (1: Completed, 2: Pending, 3: InProgress, 4: Cancelled) (optional)
- `-pr`: Priority of the task (1: Low, 2: Medium, 3: High, 4: Critical, 5: Blocker) (optional)

### List Tasks

List all tasks or filter tasks by status and priority.

list all

List a specific task by ID.

list `<id>`

Filter tasks by status or priority.

list -param "status=`<status>`"
list -param "priority=`<priority>"

- `status`: Filter tasks by status (1: Completed, 2: Pending, 3: InProgress, 4: Cancelled)
- `priority`: Filter tasks by priority (1: Low, 2: Medium, 3: High, 4: Critical, 5: Blocker)

### Update a Task

Update an existing task by ID.

update `<id>` [-t "New Title"] [-d "New Description"] [-s `<status>`] [-pr `<priority>`]

- `<id>`: ID of the task to update (required)
- `-t`: New title of the task (optional)
- `-d`: New description of the task (optional)
- `-s`: New status of the task (1: Completed, 2: Pending, 3: InProgress, 4: Cancelled) (optional)
- `-pr`: New priority of the task (1: Low, 2: Medium, 3: High, 4: Critical, 5: Blocker) (optional)

### Delete a Task

Delete a task by ID.

delete `<id>`

- `<id>`: ID of the task to delete (required)

## Example Usage

### Adding a Task

add -t "Finish Project" -d "Complete the CLI task manager project" -s 2 -pr 3

### Listing All Tasks

list all

### Listing a Specific Task by ID

list 1

### Filtering Tasks by Status

list -param "status=2"

### Filtering Tasks by Priority

list -param "priority=3"

### Updating a Task

update 1 -t "Finish Project Updated" -d "Complete the CLI task manager project with updates" -s 3 -pr 4

### Deleting a Task

delete 1

## Project Structure

- `TaskManager.cs`: Main entry point of the application.
- `Models/Task.cs`: Model representing a task.
- `Models/Status.cs`: Enumeration and model for task status.
- `Models/Priority.cs`: Enumeration and model for task priority.
- `Services/Add.cs`: Service for adding tasks.
- `Services/List.cs`: Service for listing tasks.
- `Services/Update.cs`: Service for updating tasks.
- `Services/Delete.cs`: Service for deleting tasks.
- `Services/Storage.cs`: Service for handling storage operations (loading and saving tasks).
- `Helpers/Config.cs`: Configuration settings for the application.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue if you have any suggestions or improvements.

## License

This project is licensed under the MIT License.