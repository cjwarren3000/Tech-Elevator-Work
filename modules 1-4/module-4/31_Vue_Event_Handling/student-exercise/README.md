# Vue.js Event Handling Exercise

In this exercise, you'll build on the previous exercise that asked you to display a list of users in a table. First, you'll start by creating a new user form so that new users can be added to the list. Second, you'll add the ability to select one or more users and then perform actions on them such as enable, disable, and delete. This is what the final application should look like:

![Exercise Final](./img/completed-application.png)

## Step One: Initialize the project

After opening the project folder in Visual Studio Code, open the `Terminal` menu and click on `New Terminal`. Alternatively, you may press `` Ctrl+` `` on Windows and macOS. Next, run the command `npm install` to install any dependencies before working on the project.

## Step Two: Add a new user form

The markup for the new user form is already in the template. Complete the following tasks:

- The form should be hidden by default.
  - Use a property called `showForm`.
  - Toggle `showForm` with `v-on` when the show form button is clicked.
  - Use `v-show` to show/hide the form appropriately.
- Each form field should be bound to the correct property in the `newUser` object.
- Create a `saveUser` method that adds a new user to the `users` array when the form is submitted.
  - Clear the form after the user is saved.

## Step Three: Add an enable/disable button in action column

In the "Action" column of the table, there's a button that enables or disables the user. Complete the following tasks:

- If the user status = 'Active', the button text displays 'Disable.'
- If the user status = 'Disabled', the button text displays 'Enable.'
- When you click on the button, it calls a method `flipStatus()` and change the user's status from 'Active' to 'Disabled', or 'Disabled' to 'Active.'

## Step Four: Enable, disable, and delete selected users

There are three buttons below the user listing table. Complete the following tasks associated with those buttons:

- Add a `selectedUserIDs` property that defaults to an empty array.
- When the `selectedUserIDs` array is empty, the buttons should be disabled.
  - Note: use a computed property for this.
- When the checkbox for a row is checked, add the user's ID to the `selectedUserIDs` array.
  - Bind the checked value to if the user's ID is in the `selectedUserIDs` array.
- Enable Users
  - Sets the status of each selected user to `Active`.
  - Clears all checkboxes when action is completed.
- Disable Users
  - Sets the status of each selected user to `Disabled`.
  - Clears all checkboxes when action is completed.
- Delete Users
  - Deletes the user from the `users` array.
  - Clears all checkboxes when action is completed.

> Tip: Depending how you retrieve the user ID, Vue may give it to you as a string even though it's a number. This may give you issues with comparison—try converting to a number before adding to `selectedUserIDs` if you have comparison issues.

## Step Five: Select all checkbox

The "select all" checkbox is the checkbox on the first row with the filter inputs. Complete the following tasks for the "select all" checkbox:

- When clicked to "checked" state, all boxes are checked and all users added to `selectedUserIDs`. When clicked again to "unchecked" state, all boxes are unchecked and all users removed from `selectedUserIDs`.
- If some of the boxes are checked, clicking "select all" selects all users. If clicked again, then it deselects all users.
- When all individual checkboxes get checked, then "Select all" is checked too.
- Add/remove the user IDs to/from the array depending upon the checked status of all checkboxes.
