-- Write queries to return the following:
-- Make the following changes in the "world" database.

-- 1. Add Superman's hometown, Smallville, Kansas to the city table. The 
-- countrycode is 'USA', and population of 45001. (Yes, I looked it up on 
-- Wikipedia.)

INSERT INTO city (name, countrycode, district, population)
VALUES ('Smallville', 'USA', 'Kansas', 45001);

-- 2. Add Kryptonese to the countrylanguage table. Kryptonese is spoken by 0.0001
-- percentage of the 'USA' population.
INSERT INTO countrylanguage (countrycode, language, isofficial, percentage)
VALUES ('USA', 'Kryptonese', 0, 0.0001)

-- 3. After heated debate, "Kryptonese" was renamed to "Krypto-babble", change 
-- the appropriate record accordingly.
UPDATE countrylanguage
SET language = 'Krypto-babble'
WHERE language = 'Kryptonese'

-- 4. Set the US captial to Smallville, Kansas in the country table.
UPDATE country
SET capital = 4080
WHERE capital = 3813


-- 5. Delete Smallville, Kansas from the city table. (Did it succeed? Why?)
DELETE FROM city
WHERE name = 'Smallville'

--nope, becuase Msg 547, Level 16, State 0, Line 29
--The DELETE statement conflicted with the REFERENCE constraint "FK__country__capital__3E52440B".
--The conflict occurred in database "World", table "dbo.country", column 'capital'.

-- 6. Return the US captial to Washington.
UPDATE country
SET capital = 3813
WHERE capital = 4080

-- 7. Delete Smallville, Kansas from the city table. (Did it succeed? Why?)
DELETE FROM city
WHERE name = 'Smallville'

--Yes because it is no longer the capital

-- 8. Reverse the "is the official language" setting for all languages where the
-- country's year of independence is within the range of 1800 and 1972 
-- (exclusive). 
-- (590 rows affected)
UPDATE countrylanguage
SET isofficial = ~isofficial
WHERE countrycode IN (SELECT code FROM country
WHERE country.indepyear >= 1800
AND country.indepyear <= 1972)


-- 9. Convert population so it is expressed in 1,000s for all cities. (Round to
-- the nearest integer value greater than 0.)
-- (4079 rows affected)


UPDATE city
SET population = population/1000
WHERE population > 1000


-- 10. Assuming a country's surfacearea is expressed in square miles, convert it to 
-- square meters for all countries where French is spoken by more than 20% of the 
-- population.
-- (7 rows affected)
UPDATE country
SET surfacearea =surfacearea*2590000
WHERE code IN (SELECT countrycode FROM countrylanguage
WHERE percentage > 20
AND language = 'French')
