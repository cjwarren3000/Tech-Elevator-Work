DECLARE @user_id int = 1000;

SELECT t.* FROM transfers t
JOIN accounts a on a.account_id = t.account_from
JOIN users u on u.user_id = a.user_id
WHERE u.user_id = @user_id
UNION
SELECT t.* FROM transfers t
JOIN accounts a on a.account_id = t.account_to
JOIN users u on u.user_id = a.user_id
WHERE u.user_id = @user_id


SELECT  T.account_to, u.user_id, u.username FROM transfers t
JOIN accounts a on a.account_id = t.account_to
JOIN users u on u.user_id = a.user_id
UNION
SELECT  T.account_from, u.user_id, u.username FROM transfers t
JOIN accounts a on a.account_id = t.account_from
JOIN users u on u.user_id = a.user_id