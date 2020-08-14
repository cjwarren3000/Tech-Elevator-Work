-- firstname, lastname and title of all employees with a position
SELECT * FROM Employee

SELECT * FROM Position


SELECT employee.firstname, Employee.lastname, Position.title FROM employee
INNER JOIN position
ON employee.position = Position.id

-- title and department name of all positions assigned to an department

SELECT * FROM Position

SELECT * FROM Department

SELECT p.title, d.name FROM position p
INNER JOIN Department d
ON p.department = d.id

-- firstname, lastname, title, and department name of all assigned employees

SELECT * FROM Department

SELECT * FROM Position

SELECT * FROM Employee

SELECT e.firstname, e.lastname, p.title, d.name FROM Employee e
JOIN Position p ON e.position = p.id
JOIN Department d ON p.department = d.id

-- firstname and lastname of all employees (assigned or not), include title for those that are assigned

SELECT * FROM Employee
SELECT * FROM Position

SELECT e.firstname, e.lastname, p.title FROM Employee e
LEFT OUTER JOIN Position p ON e.position = p.id

-- all position titles (assigned or not) and all employees assigned to a position (firstname and lastname)


-- above, with the opposite outer join (left or right)


-- show all employees, asigned or not (firstname and lastname) and all poistion titles, asigned or not. Show mattches where they exist (FULL OUTER JOIN)

SELECT * FROM Employee e
FULL JOIN Position p ON e.position = p.id

-- show all possible combinations of employees (firstname and lastname) and position titles, whether the combinations exist or not (CROSS JOIN)

SELECT * FROM Employee e
CROSS JOIN Position p




--
--
--








SELECT e.firstname, e.lastname, p.title
FROM employee e
INNER JOIN position p on e.position = p.id
-- JOIN position p on e.position = p.id

SELECT p.title, d.name
FROM position p 
INNER JOIN department d on p.department = d.id

SELECT e.firstname, e.lastname, p.title, d.name
FROM employee e
INNER JOIN position p on e.position = p.id
INNER JOIN department d on p.department = d.id


SELECT e.firstname, e.lastname, p.title
FROM employee e
LEFT OUTER JOIN position p on e.position = p.id
--LEFT JOIN position p on e.position = p.id

SELECT e.firstname, e.lastname, p.title
FROM employee e
RIGHT OUTER JOIN position p on e.position = p.id


SELECT e.firstname, e.lastname, p.title
FROM position p 
LEFT OUTER JOIN employee e on e.position = p.id


SELECT e.firstname, e.lastname, p.title
FROM employee e
FULL OUTER JOIN position p on e.position = p.id
--FULL JOIN position p on e.position = p.id


SELECT e.firstname, e.lastname, p.title
FROM employee e
CROSS JOIN position p 



