-- Write queries to return the following:
-- The following changes are applied to the "dvdstore" database.**

-- 1. Add actors, Hampton Avenue, and Lisa Byway to the actor table.
SELECT * FROM actor

INSERT INTO actor (first_name, last_name)
VALUES ('Hampton', 'Avenue'), ('Lisa', 'Byway')

-- 2. Add "Euclidean PI", "The epic story of Euclid as a pizza delivery boy in
-- ancient Greece", to the film table. The movie was released in 2008 in English.
-- Since its an epic, the run length is 3hrs and 18mins. There are no special
-- features, the film speaks for itself, and doesn't need any gimmicks.

SELECT * FROM film
SELECT * FROM language

INSERT INTO film (title, description, release_year, language_id, length)
VALUES ('Euclidean PI', 'The epic story of Euclid as a pizza delivery boy in
-- ancient Greece', 2008, 1, 198)

-- 3. Hampton Avenue plays Euclid, while Lisa Byway plays his slightly
-- overprotective mother, in the film, "Euclidean PI". Add them to the film.

SELECT * FROM film_actor
INSERT INTO film_actor (actor_id, film_id)
VALUES (201, 1001), (202, 1001)

-- 4. Add Mathmagical to the category table.
SELECT * FROM category
INSERT INTO category (name)
VALUES ('Mathmagical')

-- 5. Assign the Mathmagical category to the following films, "Euclidean PI",
-- "EGG IGBY", "KARATE MOON", "RANDOM GO", and "YOUNG LANGUAGE"
SELECT * FROM film_category
SELECT * FROM film
WHERE title = 'EGG IGBY' OR  title = 'KARATE MOON' OR title = 'RANDOM GO' or title = 'YOUNG LANGUAGE'
INSERT INTO film_category (film_id, category_id)
VALUES (1001, 17), (274, 17), (494, 17), (714, 17), (996, 17)

-- 6. Mathmagical films always have a "G" rating, adjust all Mathmagical films
-- accordingly.
-- (5 rows affected)

UPDATE film
SET rating = 'G'
WHERE film_id = '1001' OR film_id = '274' OR film_id = '494' OR film_id = '714' OR film_id = '996'
select film_id, rating FROM film

-- 7. Add a copy of "Euclidean PI" to all the stores.

SELECT * FROM inventory

INSERT INTO inventory (film_id, store_id)
VALUES (1001, 1), (1001, 2)

-- 8. The Feds have stepped in and have impounded all copies of the pirated film,
-- "Euclidean PI". The film has been seized from all stores, and needs to be
-- deleted from the film table. Delete "Euclidean PI" from the film table.
-- (Did it succeed? Why?)
-- <No, the film's information is being used in multiple other locations.>
DELETE FROM film
WHERE title = 'Euclidean PI'
SELECT title FROM film


-- 9. Delete Mathmagical from the category table.
-- (Did it succeed? Why?)
-- <No, because again, it is being used elsewhere>
SELECT * FROM category
DELETE FROM category
WHERE category_id = 17

-- 10. Delete all links to Mathmagical in the film_category tale.
-- (Did it succeed? Why?)
-- <yes, because there was nothing else relying on this information, therefore they can be deleted without issue.>

DELETE FROM film_category
WHERE category_id = 17

-- 11. Retry deleting Mathmagical from the category table, followed by retrying
-- to delete "Euclidean PI".
-- (Did either deletes succeed? Why?)
-- <Deleting Mathmagical worked, because there are no other tables or information that requires that particular piece of information. Deleting Euclidean PI failed because the film_actor table requires information tied to that particular movie.>

SELECT * FROM category
DELETE FROM category
WHERE category_id = 17

SELECT * FROM film
DELETE FROM film
WHERE title = 'Euclidean PI'
SELECT title FROM film

-- 12. Check database metadata to determine all constraints of the film id, and
-- describe any remaining adjustments needed before the film "Euclidean PI" can
-- be removed from the film table.

--You would need to remove the listings in the film actor table in order to remove the Euclidean PI movie, because the film_actor table 
--contains the two actor_id's connected with the film_id of Euclidean PI 
