-- ORDERING RESULTS
SELECT * FROM country
WHERE continent IN ('North America', 'South America');
-- IN keyword effectively means "includes"

-- Populations of all countries in descending order
SELECT * FROM country
ORDER BY population desc
--Names of countries and continents in ascending order
SELECT * FROM country
ORDER BY continent, name

-- LIMITING RESULTS
-- The name and average life expectancy of the countries with the 10 highest life expectancies.
SELECT TOP 10 name, lifeexpectancy FROM country
ORDER BY lifeexpectancy desc

-- CONCATENATING OUTPUTS

-- The name & state of all cities in California, Oregon, or Washington.
-- "city, state", sorted by state then city
SELECT (name + ', ' + district) location FROM city
WHERE district IN('California', 'Oregon', 'Washington')
ORDER BY district, name
-- AGGREGATE FUNCTIONS
-- Average Life Expectancy in the World
SELECT AVG(lifeexpectancy) AS WorldLifeExpectancy FROM country


-- Total population in Ohio
SELECT SUM(population) OhioPop FROM city
WHERE district IN('Ohio')

-- The surface area of the smallest country in the world
SELECT TOP 1 surfacearea FROM country
ORDER BY surfacearea asc

--or

SELECT Min(surfacearea) FROM country
-- The 10 largest countries in the world

SELECT TOP 10 surfacearea FROM country
ORDER BY surfacearea desc

-- The number of countries who declared independence in 1991
SELECT count(*) FROM country
WHERE indepyear = 1991

-- GROUP BY
-- Count the number of countries where each language is spoken, ordered from most countries to least
SELECT language, count(countrycode) AS CountryCount FROM countrylanguage
GROUP BY language
ORDER BY CountryCount desc

-- Average life expectancy of each continent ordered from highest to lowest

SELECT continent, avg(lifeexpectancy) AverageLE FROM country
GROUP BY continent
ORDER BY AverageLE desc

-- Exclude Antarctica from consideration for average life expectancy

SELECT continent, avg(lifeexpectancy) AverageLE FROM country
WHERE continent NOT IN('Antarctica')
GROUP BY continent 
ORDER BY AverageLE desc

-- Sum of the population of cities in each state in the USA ordered by state name
SELECT district, sum(population) FROM city
WHERE countrycode = 'USA'
GROUP BY district
ORDER BY district

-- The average population of cities in each state in the USA ordered by state name
SELECT district, avg(population) FROM city
WHERE countrycode = 'USA'
GROUP BY district
ORDER BY district


-- SUBQUERIES
-- Find the names of cities under a given government leader

-- Find the names of cities whose country they belong to has not declared independence yet

-- Additional samples
-- You may alias column and table names to be more descriptive

-- Alias can also be used to create shorthand references, such as "c" for city and "co" for country.

-- Ordering allows columns to be displayed in ascending order, or descending order (Look at Arlington)

-- While you can use TOP to limit the number of results returned by a query,
-- in SQL Server it is recommended to use OFFSET and FETCH if you want to get
-- "pages" of results. For instance, to get the first 10 rows in the city table
-- ordered by the name, you could use the following query.
-- (Skip 0 rows, and return only the first 10 rows from the sorted result set.)

-- Most database platforms provide string functions that can be useful for working with string data. In addition to string functions, string concatenation is also usually supported, which allows us to build complete sentences if necessary.

-- Aggregate functions provide the ability to COUNT, SUM, and AVG, as well as determine MIN and MAX. Only returns a single row of value(s) unless used with GROUP BY.
-- Counts the number of rows in the city table

-- Also counts the number of rows in the city table

-- Gets the SUM of the population field in the city table, as well as
-- the AVG population, and a COUNT of the total number of rows.

-- Gets the MIN population and the MAX population from the city table.

-- Using a GROUP BY with aggregate functions allows us to summarize information for a specific column. For instance, we are able to determine the MIN and MAX population for each countrycode in the city table.
