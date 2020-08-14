using System;

namespace VariableNaming
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            1. 4 birds are sitting on a branch. 1 flies away. How many birds are left on
            the branch?
            */

            // ### EXAMPLE:
            int initialNumberOfBirds = 4;
            int birdsThatFlewAway = 1;
            int remainingNumberOfBirds = initialNumberOfBirds - birdsThatFlewAway;
            Console.WriteLine(remainingNumberOfBirds);

            /*
            2. There are 6 birds and 3 nests. How many more birds are there than
            nests?
            */

            // ### EXAMPLE:
            int numberOfBirds = 6;
            int numberOfNests = 3;
            int numberOfExtraBirds = numberOfBirds - numberOfNests;
            Console.WriteLine(numberOfExtraBirds);


            /*
            3. 3 raccoons are playing in the woods. 2 go home to eat dinner. How
            many raccoons are left in the woods?
            */

            int numberOfPlayingRaccoons = 3;
            int numberOfRaccoonsThatLeave = 2;
            int numberOfRaccoonsLeft = numberOfPlayingRaccoons - numberOfRaccoonsThatLeave;
            Console.WriteLine(numberOfRaccoonsLeft);

            /*
            4. There are 5 flowers and 3 bees. How many less bees than flowers?
            */

            int numberOfFlowers = 5;
            int numberOfBees = 3;
            int fewerBeesThanFlowers = numberOfFlowers - numberOfBees;
            Console.WriteLine(fewerBeesThanFlowers);

            /*
            5. 1 lonely pigeon was eating breadcrumbs. Another pigeon came to eat
            breadcrumbs, too. How many pigeons are eating breadcrumbs now?
            */

            int initialPidgeons = 1;
            int bonusPidgeons = 1;
            int totalPidgeons = initialPidgeons + bonusPidgeons;
            Console.WriteLine(totalPidgeons);

            /*
            6. 3 owls were sitting on the fence. 2 more owls joined them. How many
            owls are on the fence now?
            */

            int initialOwls = 3;
            int bonusOwls = 2;
            int totalOwls = initialOwls + bonusOwls;
            Console.WriteLine(totalOwls);

            /*
            7. 2 beavers were working on their home. 1 went for a swim. How many
            beavers are still working on their home?
            */

            int hardWorkingBeavers = 2;
            int slackerBeavers = 1;
            int beaversLeftWorking = hardWorkingBeavers - slackerBeavers;
            Console.WriteLine(beaversLeftWorking);

            /*
            8. 2 toucans are sitting on a tree limb. 1 more toucan joins them. How
            many toucans in all?
            */

            int sittingToucans = 2;
            int extraToucans = 1;
            int totalToucans = sittingToucans + extraToucans;
            Console.WriteLine(totalToucans);

            /*
            9. There are 4 squirrels in a tree with 2 nuts. How many more squirrels
            are there than nuts?
            */

            int squirrels = 4;
            int nuts = 2;
            int squirrelsWithNoNuts = squirrels - nuts;
            Console.WriteLine(squirrelsWithNoNuts);

            /*
            10. Mrs. Hilt found a quarter, 1 dime, and 2 nickels. How much money did
            she find?
            */

            double quarterInCents = 25;
            double dimeInCents = 10;
            double nickelInCents = 5;
            double totalAmountInCents = (quarterInCents) + (dimeInCents) + (2 * nickelInCents);
            Console.WriteLine(totalAmountInCents);

            /*
            11. Mrs. Hilt's favorite first grade classes are baking muffins. Mrs. Brier's
            class bakes 18 muffins, Mrs. MacAdams's class bakes 20 muffins, and
            Mrs. Flannery's class bakes 17 muffins. How many muffins does first
            grade bake in all?
            */

            int mrsBriersMuffins = 18;
            int mrsMacAdamsMuffins = 20;
            int mrsFlannerysMuffins = 17;
            int mrsHiltsMuffins = mrsBriersMuffins + mrsMacAdamsMuffins + mrsFlannerysMuffins;
            Console.WriteLine(mrsHiltsMuffins);

            /*
            12. Mrs. Hilt bought a yoyo for 24 cents and a whistle for 14 cents. How
            much did she spend in all for the two toys?
            */

            double yoyoCostInCents = 24;
            double whistleCostInCents = 14;
            double totalCostOfToysInCents = yoyoCostInCents + whistleCostInCents;
            Console.WriteLine(totalCostOfToysInCents);

            /*
            13. Mrs. Hilt made 5 Rice Krispie Treats. She used 8 large marshmallows
            and 10 mini marshmallows.How many marshmallows did she use
            altogether?
            */

            int numberOfMiniMarshmallows = 10;
            int numberOfLargeMarshmallows = 8;
            int numberOfMarshmallowsUsedInTreats = numberOfMiniMarshmallows + numberOfLargeMarshmallows;
            Console.WriteLine(numberOfMarshmallowsUsedInTreats);

            /*
            14. At Mrs. Hilt's house, there was 29 inches of snow, and Brecknock
            Elementary School received 17 inches of snow. How much more snow
            did Mrs. Hilt's house have?
            */

            int inchesOfSnowAtMrsHilts = 29;
            int inchesOfSnowAtBrecknock = 17;
            int differenceOfSnowBetweenHiltsAndBrecknock = inchesOfSnowAtMrsHilts - inchesOfSnowAtBrecknock;
            Console.WriteLine(differenceOfSnowBetweenHiltsAndBrecknock);

            /*
            15. Mrs. Hilt has $10. She spends $3 on a toy truck and $2 on a pencil
            case. How much money does she have left?
            */

            double costOfTruckInDollars = 3;
            double costOfPencilCaseInDollars = 2;
            double startingMoneyInDollars = 10;
            double moneyLeftOver = startingMoneyInDollars - (costOfTruckInDollars + costOfPencilCaseInDollars);
            Console.WriteLine(moneyLeftOver);

            /*
            16. Josh had 16 marbles in his collection. He lost 7 marbles. How many
            marbles does he have now?
            */

            int initialMarbleCount = 16;
            int lostMarbles = 7;
            int marblesLeftAfterLoss = initialMarbleCount - lostMarbles;
            Console.WriteLine(marblesLeftAfterLoss);

            /*
            17. Megan has 19 seashells. How many more seashells does she need to
            find to have 25 seashells in her collection?
            */

            int initialSeashellCount = 19;
            int desiredAmountOfSeashells = 25;
            int seashellsNeededForDesiredAmount = desiredAmountOfSeashells - initialSeashellCount;
            Console.WriteLine(seashellsNeededForDesiredAmount);

            /*
            18. Brad has 17 balloons. 8 balloons are red and the rest are green. How
            many green balloons does Brad have?
            */

            int totalBalloons = 17;
            int redBalloons = 8;
            int greenBalloons = totalBalloons - redBalloons;
            Console.WriteLine(greenBalloons);

            /*
            19. There are 38 books on the shelf. Marta put 10 more books on the shelf.
            How many books are on the shelf now?
            */

            int initialNumberOfBooks = 38;
            int additionalBooks = 10;
            int totalNumberOfBooks = initialNumberOfBooks + additionalBooks;
            Console.WriteLine(totalNumberOfBooks);

            /*
            20. A bee has 6 legs. How many legs do 8 bees have?
            */

            int normalAmountOfBeeLegs = 6;
            int amountOfBees = 8;
            int totalLegsBetweenAllBees = normalAmountOfBeeLegs * amountOfBees;
            Console.WriteLine(totalLegsBetweenAllBees);

            /*
            21. Mrs. Hilt bought an ice cream cone for 99 cents. How much would 2 ice
            cream cones cost?
            */

            int iceCreamConeCostInCents = 99;
            int numberOfDesiredIceCreamCones = 2;
            int totalCostOfIceCreamConesInCents = iceCreamConeCostInCents * numberOfDesiredIceCreamCones;
            Console.WriteLine(totalCostOfIceCreamConesInCents);

            /*
            22. Mrs. Hilt wants to make a border around her garden. She needs 125
            rocks to complete the border. She has 64 rocks. How many more rocks
            does she need to complete the border?
            */

            int currentAmountOfRocks = 64;
            int amountOfRocksToCompleteBorder = 125;
            int amountOfRocksNeeded = currentAmountOfRocks + amountOfRocksToCompleteBorder;
            Console.WriteLine(amountOfRocksNeeded);

            /*
            23. Mrs. Hilt had 38 marbles. She lost 15 of them. How many marbles does
            she have left?
            */

            int initialHiltMarbles = 38;
            int hiltLosingMarbles = 15;
            int hiltMarblesLeftAfterLoss = initialHiltMarbles - hiltLosingMarbles;
            Console.WriteLine(hiltMarblesLeftAfterLoss);

            /*
            24. Mrs. Hilt and her sister drove to a concert 78 miles away. They drove 32
            miles and then stopped for gas. How many miles did they have left to drive?
            */

            int distanceToConcertInMiles = 78;
            int milesDrivenBeforeNeedingGas = 32;
            int milesLeftToDrive = distanceToConcertInMiles - milesDrivenBeforeNeedingGas;
            Console.WriteLine(milesLeftToDrive);

            /*
            25. Mrs. Hilt spent 1 hour and 30 minutes shoveling snow on Saturday
            morning and 45 minutes shoveling snow on Saturday afternoon. How
            much total time did she spend shoveling snow?
            */

            int saturdayMorningSnowShovelingTimeInMinutes = 90;
            int saturdayAfternoonSnowShovelingTimeInMinutes = 45;
            int totalTimeSpentShovelingSnowInMinutes = saturdayMorningSnowShovelingTimeInMinutes + saturdayAfternoonSnowShovelingTimeInMinutes;
            Console.WriteLine(totalTimeSpentShovelingSnowInMinutes);

            /*
            26. Mrs. Hilt bought 6 hot dogs. Each hot dog cost 50 cents. How much
            money did she pay for all of the hot dogs?
            */

            double hotDogCostInCents = 50;
            double totalHotDogsPurchased = 6;
            double totalCostOfHotDogsInCents = hotDogCostInCents * totalHotDogsPurchased;
            Console.WriteLine(totalCostOfHotDogsInCents);

            /*
            27. Mrs. Hilt has 50 cents. A pencil costs 7 cents. How many pencils can
            she buy with the money she has?
            */

            int hiltTotalMoneyInCents = 50;
            int costOfOnePencilInCents = 7;
            int totalNumberOfPencilsAbleToBePurchased = hiltTotalMoneyInCents / costOfOnePencilInCents;
            Console.WriteLine(totalNumberOfPencilsAbleToBePurchased);

            /*
            28. Mrs. Hilt saw 33 butterflies. Some of the butterflies were red and others
            were orange. If 20 of the butterflies were orange, how many of them
            were red?
            */

            int butterfliesSpotted = 33;
            int orangeButterfliesSpotted = 20;
            int numberOfRedButterflies = butterfliesSpotted - orangeButterfliesSpotted;
            Console.WriteLine(numberOfRedButterflies);

            /*
            29. Kate gave the clerk $1.00. Her candy cost 54 cents. How much change
            should Kate get back?
            */

            double paymentAmountInCents = 100;
            double costOfCandyInCents = 54;
            double changeBack = paymentAmountInCents - costOfCandyInCents;
            Console.WriteLine(changeBack);

            /*
            30. Mark has 13 trees in his backyard. If he plants 12 more, how many trees
            will he have?
            */

            int initialNumberOfTrees = 13;
            int numberOfTreesPlanted = 12;
            int totalNumberOfTrees = initialNumberOfTrees + numberOfTreesPlanted;
            Console.WriteLine(totalNumberOfTrees);

            /*
            31. Joy will see her grandma in two days. How many hours until she sees
            her?
            */

            int amountOfDaysUntilGrandma = 2;
            int amountOfHoursInOneDay = 24;
            int hoursUntilGrandma = amountOfDaysUntilGrandma * amountOfHoursInOneDay;
            Console.WriteLine(hoursUntilGrandma);

            /*
            32. Kim has 4 cousins. She wants to give each one 5 pieces of gum. How
            much gum will she need?
            */

            int numberOfCousins = 4;
            int piecesOfGumPerCousin = 5;
            int totalAmountOfGumNeeded = numberOfCousins * piecesOfGumPerCousin;
            Console.WriteLine(totalAmountOfGumNeeded);

            /*
            33. Dan has $3.00. He bought a candy bar for $1.00. How much money is
            left?
            */

            int danTotalMoneyInCents = 300;
            int costOfDanCandyInCents = 100;
            int danMoneyLeftAfterCandy = danTotalMoneyInCents - costOfDanCandyInCents;
            Console.WriteLine(danMoneyLeftAfterCandy);

            /*
            34. 5 boats are in the lake. Each boat has 3 people. How many people are
            on boats in the lake?
            */

            int numberOfBoatsInLake = 5;
            int numberOfPeoplePerBoat = 3;
            int numberOfPeopleOnBoats = numberOfBoatsInLake * numberOfPeoplePerBoat;
            Console.WriteLine(numberOfPeopleOnBoats);

            /*
            35. Ellen had 380 legos, but she lost 57 of them. How many legos does she
            have now?
            */

            int initialEllenLegosCount = 380;
            int ellenLegosLost = 57;
            int ellenLegosLeftAfterLoss = initialEllenLegosCount - ellenLegosLost;
            Console.WriteLine(ellenLegosLeftAfterLoss);

            /*
            36. Arthur baked 35 muffins. How many more muffins does Arthur have to
            bake to have 83 muffins?
            */

            int arthurMuffinsBaked = 35;
            int desiredAmountOfArthurMuffins = 83;
            int amountOfArthurMuffinsLeftToBake = desiredAmountOfArthurMuffins - arthurMuffinsBaked;
            Console.WriteLine(amountOfArthurMuffinsLeftToBake);

            /*
            37. Willy has 1400 crayons. Lucy has 290 crayons. How many more
            crayons does Willy have then Lucy?
            */

            int totalNumberOfWillyCrayons = 1400;
            int totalNumberOfLucyCrayons = 290;
            int numberOfCrayonsWillyHasOverLucy = totalNumberOfWillyCrayons - totalNumberOfLucyCrayons;
            Console.WriteLine(numberOfCrayonsWillyHasOverLucy);

            /*
            38. There are 10 stickers on a page. If you have 22 pages of stickers, how
            many stickers do you have?
            */

            int stickersPerPage = 10;
            int pagesOfStickers = 22;
            int numberOfStickers = stickersPerPage * pagesOfStickers;
            Console.WriteLine(numberOfStickers);

            /*
            39. There are 96 cupcakes for 8 children to share. How much will each
            person get if they share the cupcakes equally?
            */

            int totalNumberOfCupcakes = 96;
            int numberOfChildren = 8;
            int numberOfCupcakesEachChildReceives = totalNumberOfCupcakes / numberOfChildren;
            Console.WriteLine(numberOfCupcakesEachChildReceives);

            /*
            40. She made 47 gingerbread cookies which she will distribute equally in
            tiny glass jars. If each jar is to contain six cookies each, how many
            cookies will not be placed in a jar?
            */

            int numberOfGingerbreadCookies = 47;
            int numberOfCookiesInJar = 6;
            int numberOfGingerbreadCookiesLeftover = numberOfGingerbreadCookies % numberOfCookiesInJar;
            Console.WriteLine(numberOfGingerbreadCookiesLeftover);

            /*
            41. She also prepared 59 croissants which she plans to give to her 8
            neighbors. If each neighbor received and equal number of croissants,
            how many will be left with Marian?
            */

            int numberOfCroissants = 59;
            int numberOfNeighbors = 8;
            int leftOverCroissants = numberOfCroissants % numberOfNeighbors;
            Console.WriteLine(leftOverCroissants);

            /*
            42. Marian also baked oatmeal cookies for her classmates. If she can
            place 12 cookies on a tray at a time, how many trays will she need to
            prepare 276 oatmeal cookies at a time?
            */

            int numberOfCookiesPerTray = 12;
            int totalNumberOfCookiesDesired = 276;
            int numberOfTraysNeeded = totalNumberOfCookiesDesired / numberOfCookiesPerTray; 
            /*this results in an even number for this particular instance, but I'm not sure how I
            would make this show one extra tray if there are any leftover cookies... Barring going
            a bit overboard and using an if else clause. I feel like there is a simpler method.
            */
            Console.WriteLine(numberOfTraysNeeded);

            /*
            43. Marian’s friends were coming over that afternoon so she made 480
            bite-sized pretzels. If one serving is equal to 12 pretzels, how many
            servings of bite-sized pretzels was Marian able to prepare?
            */

            int numberOfPretzelsMade = 480;
            int numberOfPretzelsPerServing = 12;
            int numberOfServingsOfPretzels = numberOfPretzelsMade / numberOfPretzelsPerServing;
            Console.WriteLine(numberOfServingsOfPretzels);

            /*
            44. Lastly, she baked 53 lemon cupcakes for the children living in the city
            orphanage. If two lemon cupcakes were left at home, how many
            boxes with 3 lemon cupcakes each were given away?
            */

            int numberOfLemonCupcakes = 53;
            int numberOfLemonCupcakesLeftAtHome = 2;
            int numberOfLemonCupcakesPerBox = 3;
            int numberOfBoxesGivenAway = (numberOfLemonCupcakes - numberOfLemonCupcakesLeftAtHome) / numberOfLemonCupcakesPerBox;
            Console.WriteLine(numberOfBoxesGivenAway);

            /*
            45. Susie's mom prepared 74 carrot sticks for breakfast. If the carrots
            were served equally to 12 people, how many carrot sticks were left
            uneaten?
            */

            int carrotSticksPrepared = 74;
            int numberOfPeopleEatingCarrotSticks = 12;
            int numberOfCarrotSticksLeftOver = carrotSticksPrepared % numberOfPeopleEatingCarrotSticks;
            Console.WriteLine(numberOfCarrotSticksLeftOver);

            /*
            46. Susie and her sister gathered all 98 of their teddy bears and placed
            them on the shelves in their bedroom. If every shelf can carry a
            maximum of 7 teddy bears, how many shelves will be filled?
            */

            int totalTeddyBears = 98;
            int shelfBearLimit = 7;
            int totalShelvesFilledWithBears = totalTeddyBears / shelfBearLimit;
            Console.WriteLine(totalShelvesFilledWithBears);

            /*
            47. Susie’s mother collected all family pictures and wanted to place all of
            them in an album. If an album can contain 20 pictures, how many
            albums will she need if there are 480 pictures?
            */

            int totalPicturesPerAlbum = 20;
            int totalFamilyPictures = 480;
            int albumsNeededForAllPictures = totalFamilyPictures / totalPicturesPerAlbum;
            Console.WriteLine(albumsNeededForAllPictures);

            /*
            48. Joe, Susie’s brother, collected all 94 trading cards scattered in his
            room and placed them in boxes. If a full box can hold a maximum of 8
            cards, how many boxes were filled and how many cards are there in
            the unfilled box?
            */

            int totalNumberOfTradingCards = 94;
            int maxmimumCardsPerBox = 8;
            int boxesFilledWithCards = totalNumberOfTradingCards / maxmimumCardsPerBox;
            int cardsInUnfilledBox = totalNumberOfTradingCards % maxmimumCardsPerBox;
            Console.WriteLine("Total full boxes: " + boxesFilledWithCards + " Cards in Unfilled Box: " + cardsInUnfilledBox);

            /*
            49. Susie’s father repaired the bookshelves in the reading room. If he has
            210 books to be distributed equally on the 10 shelves he repaired,
            how many books will each shelf contain?
            */

            int numberOfBooksToShelve = 210;
            int numberOfShelvesRepaired = 10;
            int numberOfBooksPerShelf = numberOfBooksToShelve / numberOfShelvesRepaired;
            Console.WriteLine(numberOfBooksPerShelf);

            /*
            50. Cristina baked 17 croissants. If she planned to serve this equally to
            her seven guests, how many will each have?
            */

            int numberOfCroissantsToServe = 17;
            int numberOfGuestsEatingCroissants = 7;
            int numberOfCroissantsPerGuest = numberOfCroissantsToServe / numberOfGuestsEatingCroissants;
            Console.WriteLine(numberOfCroissantsPerGuest);

            /*
                CHALLENGE (Optional) PROBLEMS
            */

            /*
            Bill and Jill are house painters. Bill can paint a 12 x 14 room in 2.15 hours, while Jill averages
            1.90 hours. How long will it take the two painter working together to paint 5 12 x 14 rooms?
            Hint: Calculate the hourly rate for each painter, combine them, and then divide the total walls in feet by the combined hourly rate of the painters.
            Challenge: How many days will it take the pair to paint 623 rooms assuming they work 8 hours a day?.
            */

            /*
            Create and assign variables to hold your first name, last name, and middle initial. Using concatenation,
            build an additional variable to hold your full name in the order of last name, first name, middle initial. The
            last and first names should be separated by a comma followed by a space, and the middle initial must end
            with a period.
            Example: "Hopper, Grace B."
            */

            /*
            The distance between New York and Chicago is 800 miles, and the train has already travelled 537 miles.
            What percentage of the trip has been completed?
            Hint: The percent completed is the miles already travelled divided by the total miles.
            Challenge: Display as an integer value between 0 and 100 using casts.
            */
            Console.ReadLine();
        }
    }
}
