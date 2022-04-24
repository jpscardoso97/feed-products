# SQL Test Assignment


**Answers:**


1. Select users whose id is either 3,2 or 4
- Please return at least: all user fields

    ``` SQL
    SELECT * FROM users u WHERE id in (2,3,4)

2. Count how many basic and premium listings each active user has
- Please return at least: first_name, last_name, basic, premium

    **Assuming that the status of the listing refers to the basic/premium (2/3) type of listing and that an active user has status=2:**

    ``` SQL
    SELECT  
	    u.first_name,  
	    u.last_name,
	    sum(CASE WHEN l.status=2 THEN 1 ELSE 0 END) AS basic,
	    sum(CASE WHEN l.status=3 THEN 1 ELSE 0 END) AS premium
    FROM
	    users u,
	    listings l
    WHERE
	    l.user_id = u.id
	    AND u.status = 2
    GROUP BY
	    u.id
    ```  

3. Show the same count as before but only if they have at least ONE premium listing
- Please return at least: first_name, last_name, basic, premium

    ``` SQL
    SELECT  
	    u.first_name,  
	    u.last_name,
	    sum(CASE WHEN l.status=2 THEN 1 ELSE 0 END) AS basic,
	    sum(CASE WHEN l.status=3 THEN 1 ELSE 0 END) AS premium
    FROM
	    users u,
	    listings l
    WHERE
	    l.user_id = u.id
	    AND u.status = 2
    GROUP BY
	    u.id
    HAVING
	    premium > 0
    ```  

4. How much revenue has each active vendor made in 2013
- Please return at least: first_name, last_name, currency, revenue

    ``` SQL
    SELECT
        u.first_name,
        u.last_name,
        c.currency,
        sum(c.price) AS revenue
    FROM
        users u,
        listings l,
        clicks c
    WHERE
        l.user_id = u.id
        AND u.status = 2
        AND l.id = c.listing_id
        AND c.created BETWEEN '2012-12-31' AND '2014-01-01'
    GROUP BY
        u.id,
	    c.currency
    ```

5. Insert a new click for listing id 3, at $4.00
- Find out the id of this new click. Please return at least: id

    ``` SQL
    INSERT INTO clicks (listing_id, price, currency, created) VALUES (3, 5, 'USD', NOW());
    SELECT LAST_INSERT_ID();
    ```

6. Show listings that have not received a click in 2013
- Please return at least: listing_name

   ``` SQL
    SELECT
        l.name
    FROM
        listings l,
        clicks c
    WHERE
        l.id = c.listing_id
    GROUP BY
        l.id
    HAVING
        sum(CASE WHEN c.created BETWEEN'2012-12-31' AND'2014-01-01' THEN 1 ELSE 0 END) = 0
    ```

7. For each year show number of listings clicked and number of vendors who owned these listings
- Please return at least: date, total_listings_clicked, total_vendors_affected

    ``` SQL
    SELECT
        EXTRACT(YEAR FROM c.created),
        COUNT(DISTINCT l.id) AS total_listings_clicked,
        COUNT(DISTINCT u.id) AS total_vendors_affected
    FROM
        listings l,
        clicks c,
        users u
    WHERE
        l.id = c.listing_id
        AND u.id = l.user_id
    GROUP BY
	    EXTRACT(YEAR FROM c.created)
    ```

8. Return a comma separated string of listing names for all active vendors
- Please return at least: first_name, last_name, listing_names

    ``` SQL
    TBD