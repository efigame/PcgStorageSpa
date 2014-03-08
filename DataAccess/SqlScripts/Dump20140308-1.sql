CREATE DATABASE  IF NOT EXISTS `pcgstorage` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `pcgstorage`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: localhost    Database: pcgstorage
-- ------------------------------------------------------
-- Server version	5.7.3-m13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `adventuredeck`
--

DROP TABLE IF EXISTS `adventuredeck`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `adventuredeck` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `AdventurePathId` int(11) NOT NULL,
  `Index` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_deck_adventure_id_idx` (`AdventurePathId`),
  CONSTRAINT `fk_expansion_adventure_id` FOREIGN KEY (`AdventurePathId`) REFERENCES `adventurepath` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adventuredeck`
--

LOCK TABLES `adventuredeck` WRITE;
/*!40000 ALTER TABLE `adventuredeck` DISABLE KEYS */;
INSERT INTO `adventuredeck` VALUES (1,'Perils of the Lost Coast',1,1),(2,'Burnt Offerings',2,1),(3,'The Skinsaw Murders',2,2),(4,'Hook Mountain Massacre',2,3),(5,'Fortress of the Stone Giants',2,4),(6,'Sins of the Saviors',2,5),(7,'Spires of Xin-Shalast',2,6);
/*!40000 ALTER TABLE `adventuredeck` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `adventurepath`
--

DROP TABLE IF EXISTS `adventurepath`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `adventurepath` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `adventurepath`
--

LOCK TABLES `adventurepath` WRITE;
/*!40000 ALTER TABLE `adventurepath` DISABLE KEYS */;
INSERT INTO `adventurepath` VALUES (1,'None'),(2,'Rise of the Runelords'),(3,'Skull & Shackles');
/*!40000 ALTER TABLE `adventurepath` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `card`
--

DROP TABLE IF EXISTS `card`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `card` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(200) NOT NULL,
  `DeckId` int(11) NOT NULL,
  `CardTypeId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_card_deck_id_idx` (`DeckId`),
  KEY `fk_card_cardtype_id_idx` (`CardTypeId`),
  CONSTRAINT `fk_card_cardtype_id` FOREIGN KEY (`CardTypeId`) REFERENCES `cardtype` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=470 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `card`
--

LOCK TABLES `card` WRITE;
/*!40000 ALTER TABLE `card` DISABLE KEYS */;
INSERT INTO `card` VALUES (1,'Ezren',1,1),(2,'Harsk',1,1),(3,'Kyra',1,1),(4,'Lem',1,1),(5,'Merisiel',1,1),(6,'Seoni',1,1),(7,'Valeros',1,1),(8,'Amiri',2,1),(9,'Lini',2,1),(10,'Sajan',2,1),(11,'Seelah',2,1),(12,'Rise of the Runelords',1,2),(13,'Perils of the Lost Coast',1,3),(14,'Brigandoom',1,4),(15,'The Poison Pill',1,4),(16,'Black Fang\'s Dungeon',1,4),(17,'Academy',1,5),(18,'Apothecary',1,5),(19,'City Gate',1,5),(20,'Deeper Dungeons',1,5),(21,'Desecrated Vault',1,5),(22,'Farmhouse',1,5),(23,'Garrison',1,5),(24,'General Store',1,5),(25,'Guard Tower',1,5),(26,'Mountain Peak',1,5),(27,'Prison',1,5),(28,'Sandpoint Cathedral',1,5),(29,'Shrine to Lamashtu',1,5),(30,'Temple',1,5),(31,'Thassilonian Dungeon',1,5),(32,'The Old Light',1,5),(33,'Throne Room',1,5),(34,'Treacherous Cave',1,5),(35,'Town Square',1,5),(36,'Village House',1,5),(37,'Warrens',1,5),(38,'Waterfront',1,5),(39,'Wooden Bridge',1,5),(40,'Woods',1,5),(41,'Black Fang',1,6),(42,'Jubrayl Vhiski',1,6),(43,'Pillbug Podicker',1,6),(44,'Ancient Skeleton',1,7),(45,'Bandit',1,7),(46,'Poison Trap',1,7),(47,'Bugbear',1,8),(48,'Bunyip',1,8),(49,'Cultist',1,8),(50,'Enchanter',1,8),(51,'Ghost',1,8),(52,'Ghoul',1,8),(53,'Giant Gecko',1,8),(54,'Goblin Commando',1,8),(55,'Goblin Warrior',1,8),(56,'Hell Hound',1,8),(57,'Hill Giant',1,8),(58,'Mercenary',1,8),(59,'Ogre',1,8),(60,'Plague Zombie',1,8),(61,'Rat Swarm',1,8),(62,'Scout',1,8),(63,'Shadow',1,8),(64,'Siren',1,8),(65,'Skeleton',1,8),(66,'Sneak',1,8),(67,'Spectre',1,8),(68,'Traitor',1,8),(69,'Warlord',1,8),(70,'Werewolf',1,8),(71,'Xulgath',1,8),(72,'Zombie',1,8),(73,'Zombie Giant',1,8),(74,'Ambush',1,9),(75,'Battered Chest',1,9),(76,'Collapsed Ceiling',1,9),(77,'Explosive Runes',1,9),(78,'Large Chest',1,9),(79,'Locked Passage',1,9),(80,'Mystic Inscription',1,9),(81,'Pit Trap',1,9),(82,'Skeleton Horde',1,9),(83,'Trapped Locker',1,9),(84,'Trapped Passageway',1,9),(85,'Treasure Map',1,9),(86,'Bastard Sword',1,10),(87,'Battleaxe',1,10),(88,'Dagger',1,10),(89,'Dart',1,10),(90,'Flaming Mace +1',1,10),(91,'Glaive',1,10),(92,'Greataxe',1,10),(93,'Heavy Crossbow',1,10),(94,'Light Crossbow',1,10),(95,'Longbow',1,10),(96,'Longspear',1,10),(97,'Longsword',1,10),(98,'Longsword +1',1,10),(99,'Mace',1,10),(100,'Quarterstaff',1,10),(101,'Returning Throwing Axe +1',1,10),(102,'Scimitar',1,10),(103,'Shock Longbow +1',1,10),(104,'Short Sword',1,10),(105,'Shortbow',1,10),(106,'Sling',1,10),(107,'Spiked Chain',1,10),(108,'Starknife',1,10),(109,'Throwing Axe',1,10),(110,'Warhammer',1,10),(111,'Warhammer +1',1,10),(112,'Acid Arrow',1,11),(113,'Aid',1,11),(114,'Arcane Armor',1,11),(115,'Augury',1,11),(116,'Charm Person',1,11),(117,'Cure',1,11),(118,'Detect Evil',1,11),(119,'Detect Magic',1,11),(120,'Find Traps',1,11),(121,'Force Missile',1,11),(122,'Glibness',1,11),(123,'Guidance',1,11),(124,'Holy Light',1,11),(125,'Inflict',1,11),(126,'Invisibility',1,11),(127,'Levitate',1,11),(128,'Lightning Touch',1,11),(129,'Mending',1,11),(130,'Mirror Image',1,11),(131,'Sanctuary',1,11),(132,'Sleep',1,11),(133,'Strength',1,11),(134,'Chain Mail',1,13),(135,'Elven Chain Shirt',1,13),(136,'Half-Plate',1,13),(137,'Leather Armor',1,13),(138,'Magic Chain Mail',1,13),(139,'Magic Half-Plate',1,13),(140,'Magic Leather Armor',1,13),(141,'Magic Shield',1,13),(142,'Wooden Shield',1,13),(143,'Amulet of Fortitude',1,14),(144,'Amulet of Life',1,14),(145,'Blast Stone',1,14),(146,'Boots of Elvenkind',1,14),(147,'Bracers of Protection',1,14),(148,'Caltrops',1,14),(149,'Cape of Escape',1,14),(150,'Codex',1,14),(151,'Crowbar',1,14),(152,'Holy Candle',1,14),(153,'Holy Water',1,14),(154,'Luckstone',1,14),(155,'Masterwork Tools',1,14),(156,'Mattock',1,14),(157,'Potion of Energy Resistance',1,14),(158,'Potion of Fortitude',1,14),(159,'Potion of Ghostly Form',1,14),(160,'Potion of Glibness',1,14),(161,'Potion of Healing',1,14),(162,'Potion of Hiding',1,14),(163,'Potion of Vision',1,14),(164,'Spyglass',1,14),(165,'Thieve\'s Tools',1,14),(166,'Token of Remembrance',1,14),(167,'Tome of Knowledge',1,14),(168,'Acolyte',1,15),(169,'Archer',1,15),(170,'Burglar',1,15),(171,'Crow',1,15),(172,'Father Zantus',1,15),(173,'Guard',1,15),(174,'Guide',1,15),(175,'Mayor Kendra Deverin',1,15),(176,'Night Watch',1,15),(177,'Sage',1,15),(178,'Shalelu Andosana',1,15),(179,'Sheriff Hemlock',1,15),(180,'Soldier',1,15),(181,'Standard Bearer',1,15),(182,'Troubadour',1,15),(183,'Blessing of Calistria',1,16),(184,'Blessing of Desna',1,16),(185,'Blessing of Erastil',1,16),(186,'Blessing of Gorum',1,16),(187,'Blessing of Iomedae',1,16),(188,'Blessing of Irori',1,16),(189,'Blessing of Pharasma',1,16),(190,'Blessing of Sarenrae',1,16),(191,'Blessing of Shelyn',1,16),(192,'Blessing of the Gods',1,16),(193,'Blessing of Torag',1,16),(194,'Fire Sneeze',9,11),(195,'Poog of Zarongel',9,15),(196,'Blessing of Zarongel',9,16),(197,'Satyr',2,8),(198,'Secret Stash',2,9),(199,'Allying Dart +1',2,10),(200,'Deathbane Light Crossbow +1',2,10),(201,'Greatsword',2,10),(202,'Icy Longspear +1',2,10),(203,'Amulet of Mighty Fists',2,14),(204,'Crown of Charisma',2,14),(205,'Eyes of the Eagle',2,14),(206,'Sage\'s journal',2,14),(207,'Dog',2,15),(208,'Saber-Toothed Tiger',2,15),(209,'Snake',2,15),(210,'Burnt Offerings',3,3),(211,'Attack on Sandpoint',3,4),(212,'Local Heroes',3,4),(213,'Trouble in Sandpoint',3,4),(214,'Approach to Thistletop',3,4),(215,'Thistletop Delve',3,4),(216,'Catacombs of Wrath',3,5),(217,'Glassworks',3,5),(218,'Goblin Fortress',3,5),(219,'Junk Beach',3,5),(220,'Nettlemaze',3,5),(221,'Swallowtail Festival',3,5),(222,'The Rusty Dragon',3,5),(223,'Erylium',3,6),(224,'Gogmurt',3,6),(225,'Nualia',3,6),(226,'Ripnugget and Stickfoot',3,6),(227,'The Sandpoint Devil',3,6),(228,'Bruthazmus',3,7),(229,'Goblin Raider',3,7),(230,'Koruvus',3,7),(231,'Lyrie Akenja',3,7),(232,'Orik Vancaskerkin',3,7),(233,'Tangletooth',3,7),(234,'Tsuto Kaikitsu',3,7),(235,'Wrathful Sinspawn',3,7),(236,'Attic Whisperer',3,8),(237,'Giant Hermit Crab',3,8),(238,'Goblin Cutpurse',3,8),(239,'Goblin Dog',3,8),(240,'Goblin Pyro',3,8),(241,'Goblin Snake',3,8),(242,'Goblin Warchanter',3,8),(243,'Tickwood Boar',3,8),(244,'Yeth Hound',3,8),(245,'Goblin Raid',3,9),(246,'Monster in the Closet',3,9),(247,'Pit of Malfeshnekor',3,9),(248,'Shopkeeper\'s Daughter',3,9),(249,'Slashing Blade',3,9),(250,'Bastard Sword +1',3,10),(251,'Dagger +1',3,10),(252,'Dogslicer',3,10),(253,'Dogslicer +1',3,10),(254,'Longbow +1',3,10),(255,'Short Sword +1',3,10),(256,'Enfeeble',3,11),(257,'Fiery Weapon',3,11),(258,'Frost Ray',3,11),(259,'Scorching Ray',3,11),(260,'Speed',3,11),(261,'Sihedron  Medallion',3,14),(262,'Elven Breastplate',3,13),(263,'Shield of Fire Resistance',3,13),(264,'Potion of Gracefulness',3,14),(265,'Potion of Ruggedness',3,14),(266,'Staff of Minor Healing',3,14),(267,'Wand of Force Missile',3,14),(268,'Wand of Shield',3,14),(269,'Aldern Foxglove',3,15),(270,'Ameik Kaijitsu',3,15),(271,'Cyrdak Drokkus',3,15),(272,'Grizzled Mercenary',3,15),(273,'Ilsoari Gandethus',3,15),(274,'Toad',3,15),(275,'Ven Vinder',3,15),(276,'Blessing of Lamashtu',3,16),(277,'The Skinsaw Murders',4,3),(278,'The Hook Mountain Massacre',5,3),(279,'Fortress of the Stone Giants',6,3),(280,'Undead Uprising',4,4),(281,'Crow Bait',4,4),(282,'Foul Misgivings',4,4),(283,'The Cult Exposed',4,4),(284,'Angel in the Tower',4,4),(285,'Them Ogres Ain\'t Right',5,4),(286,'The Fort in Peril',5,4),(287,'Here Comes the Flood',5,4),(288,'Battle at the Dam',5,4),(289,'Into the Mountains',5,4),(290,'Sandpoint Under Siege',6,4),(291,'Jorgenfist',6,4),(292,'The Black Tower',6,4),(293,'Under Jorgenfist',6,4),(294,'The Ancient Library',6,4),(295,'Foxglove Manor',4,5),(296,'Habe\'s Sanatorium',4,5),(297,'Mill',4,5),(298,'Shadow Clock',4,5),(299,'Dam',5,5),(300,'Fort Rannick',5,5),(301,'Shimmerglens',5,5),(302,'Turtleback Ferry',5,5),(303,'Courtyard',6,5),(304,'Giant Lair',6,5),(305,'Scarnetti Manor',6,5),(306,'Thassilonian Library',6,5),(307,'Caizarlu Zerren',4,6),(308,'Iesha Foxglove',4,6),(309,'Justice Ironbriar',4,6),(310,'Rogors Craesby',4,6),(311,'The Skinsaw Man',4,6),(312,'Xanesha',4,6),(313,'Barl Breakbones',5,6),(314,'Black Magga',5,6),(315,'Jaagrath Kreeg',5,6),(316,'Malugus Kreeg',5,6),(317,'Mammy Graul',5,6),(318,'Galenmir',6,6),(319,'Mokmurian',6,6),(320,'Seleval',6,6),(321,'Teraktinus',6,6),(322,'The Black Monk',6,6),(323,'Zaelsar',6,6),(324,'Charmed Faceless Stalker',4,7),(325,'Dr. Habe',4,7),(326,'Ghoul Scarecrow',4,7),(327,'Grayst Sevilla',4,7),(328,'Haunt',4,7),(329,'Pidget Tergleson',4,7),(330,'Scarecrow Golem',4,7),(331,'Skinsaw Cultist',4,7),(332,'Zombie Minions',4,7),(333,'Crowfood Graul',5,7),(334,'Dorella and Hookmaw Kreeg',5,7),(335,'Graul Ogrekin',5,7),(336,'Hook Mountain Hag',5,7),(337,'Kaven Windstrike',5,7),(338,'Kreeg Ogre',5,7),(339,'Lamatar Bayden',5,7),(340,'Lucrecia',5,7),(341,'Lunderbud',5,7),(342,'Nightbelly Boa',5,7),(343,'Ruckus Graul and Hound',5,7),(344,'Cinderma',6,7),(345,'Enga Keckvia',6,7),(346,'Forgefiend',6,7),(347,'Harpy Monk',6,7),(348,'Headless Lord',6,7),(349,'Hill Giant Runeslave',6,7),(350,'Jorgenfist Stone Giant',6,7),(351,'Lokansir',6,7),(352,'Longtooth',6,7),(353,'Tyrant Troll',6,7),(354,'Carrionstorm',4,8),(355,'Diseased Rats',4,8),(356,'Faceless Stalker',4,8),(357,'Ghoul',4,8),(358,'Donkey Rats',5,8),(359,'Grazuul',5,8),(360,'Hag',5,8),(361,'Muck Graul',5,8),(362,'Myriana',5,8),(363,'Ogre',5,8),(364,'Ogrekin',5,8),(365,'Skull Ripper',5,8),(366,'Cave Bear',6,8),(367,'Deathweb',6,8),(368,'Ghoul Bat',6,8),(369,'Harpy',6,8),(370,'Hill Giant',6,8),(371,'Mammoth',6,8),(372,'Red Cap',6,8),(373,'Roc',6,8),(374,'Shining Child',6,8),(375,'Stone Giant',6,8),(376,'Troll',6,8),(377,'Wyvern',6,8),(378,'Falling Bell',4,9),(379,'Locked Stone Door',4,9),(380,'Skinsaw Ritual',4,9),(381,'Zombie Horde',4,9),(382,'Zombie Nest',4,9),(383,'Cryptic Message',5,9),(384,'Door Spike',5,9),(385,'Hand Chopper',5,9),(386,'Ranger Stash',5,9),(387,'Arcane Lock',6,9),(388,'Circles of Binding',6,9),(389,'Invasion Plans',6,9),(390,'Reduction Field',6,9),(391,'Heavy Pick +1',4,10),(392,'Light Crossbow +1',4,10),(393,'Scythe +1',4,10),(394,'Sickle +1',4,10),(395,'War Razor +1',4,10),(396,'Frost Longbow +1',5,10),(397,'Longsword +2',5,10),(398,'Venomous Dagger +2',5,10),(399,'Vicious Trident +1',5,10),(400,'Giantbane Dagger +1',6,10),(401,'Greatclub +3',6,10),(402,'Runechill Hatchet +2',6,10),(403,'Shortspear +3',6,10),(404,'Consecration',4,11),(405,'Haste',4,11),(406,'Lighting Bolt',4,11),(407,'Toxic Cloud',4,11),(408,'Web',4,11),(409,'Incendiary',5,11),(410,'Major Cure',5,11),(411,'Scrying',5,11),(412,'Swipe',5,11),(413,'Mass Cure',6,11),(414,'Poison Blast',6,11),(415,'Restoration',6,11),(416,'Teleport',6,11),(417,'Arrow Catching Studded Leather',4,13),(418,'Deathbane Shield',4,13),(419,'Hide Armor of Fire Resistance',4,13),(420,'Magic Full Plate',5,13),(421,'Magic Studded Leather Armor',5,13),(422,'Spiny Shield',5,13),(423,'Breastplate of Fire Resistance',6,13),(424,'Chainmail of Cold Resistance',6,13),(425,'Lesser Bolstering Armor',6,13),(426,'Reflecting Shield',6,13),(427,'Impaler of Thorns',4,10),(428,'Medusa Mask',4,14),(429,'Sihedron  Medallion',4,14),(430,'Snakeskin Tunic',4,13),(431,'Headband of Vast Intelligence',5,12),(432,'Sihedron  Medallion',5,12),(433,'Wand of Enervation',5,12),(434,'Emerald Codex',6,12),(435,'Mokmurian\'s Club',6,12),(436,'Robe of Runes',6,12),(437,'Chime of Unlocking',4,14),(438,'Cloak of Elvenkind',4,14),(439,'Ring of Protection',4,14),(440,'Belt of Giant Strength',5,14),(441,'Belt of Incredible Dexterity',5,14),(442,'Headband of Alluring Charisma',5,14),(443,'Wand of Scorching Ray',5,14),(444,'Amulet of Fiery Fists',6,14),(445,'Bracers of Greater Protection',6,14),(446,'Greater Luckstone',6,14),(447,'Headband of Inspired Wisdom',6,14),(448,'Magic Spyglass',6,14),(449,'Necklace of Fireballs',6,14),(450,'Staff of Heaven and Earth',6,14),(451,'Brodert Quink',4,15),(452,'Maester Grump',4,15),(453,'Merchant',4,15),(454,'Black Arrow Ranger',5,15),(455,'Cat',5,15),(456,'Giant Badger',5,15),(457,'Jakardos Sovark',5,15),(458,'Monkey',5,15),(459,'Vale Temros',5,15),(460,'Yap the Pixie',5,15),(461,'Bear',6,15),(462,'Charmed Red Dragon',6,15),(463,'Clockwork Librarian',6,15),(464,'Conna the Wise',6,15),(465,'Eagle',6,15),(466,'Lizard',6,15),(467,'Blessing of Abadar',4,16),(468,'Blessing of Norgorber',5,16),(469,'Blessing of Gorzreh',6,16);
/*!40000 ALTER TABLE `card` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cardtype`
--

DROP TABLE IF EXISTS `cardtype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cardtype` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cardtype`
--

LOCK TABLES `cardtype` WRITE;
/*!40000 ALTER TABLE `cardtype` DISABLE KEYS */;
INSERT INTO `cardtype` VALUES (1,'Character'),(2,'Adventure Path'),(3,'Adventure'),(4,'Scenario'),(5,'Location'),(6,'Villain'),(7,'Henchman'),(8,'Monster'),(9,'Barrier'),(10,'Weapon'),(11,'Spell'),(12,'Loot'),(13,'Armor'),(14,'Item'),(15,'Ally'),(16,'Blessing');
/*!40000 ALTER TABLE `cardtype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `character`
--

DROP TABLE IF EXISTS `character`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `character` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PartyId` int(11) NOT NULL,
  `CharacterCardId` int(11) NOT NULL,
  `LightArmors` int(11) DEFAULT NULL,
  `HeavyArmors` int(11) DEFAULT NULL,
  `Weapons` int(11) DEFAULT NULL,
  `WeaponCards` int(11) DEFAULT NULL,
  `SpellCards` int(11) DEFAULT NULL,
  `ArmorCards` int(11) DEFAULT NULL,
  `ItemCards` int(11) DEFAULT NULL,
  `AllyCards` int(11) DEFAULT NULL,
  `BlessingCards` int(11) DEFAULT NULL,
  `HandSize` int(11) DEFAULT NULL,
  `DeletedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_party_id_idx` (`PartyId`),
  KEY `fk_charactercard_id_idx` (`CharacterCardId`),
  CONSTRAINT `fk_character_party` FOREIGN KEY (`PartyId`) REFERENCES `party` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_character_charactercard` FOREIGN KEY (`CharacterCardId`) REFERENCES `charactercard` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `character`
--

LOCK TABLES `character` WRITE;
/*!40000 ALTER TABLE `character` DISABLE KEYS */;
INSERT INTO `character` VALUES (1,1,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(3,2,3,2,0,1,3,0,1,3,4,0,0,NULL),(4,2,1,2,2,1,4,0,0,0,0,0,6,NULL),(6,3,2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(7,1,81,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(8,1,2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(9,1,3,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(10,1,77,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(11,1,78,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(12,1,79,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(13,1,80,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(14,1,82,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(15,1,83,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(16,1,84,2,2,2,3,1,3,0,2,6,5,NULL),(17,4,1,2,2,1,0,0,3,0,0,0,6,NULL),(18,4,2,0,0,0,1,0,0,4,3,10,6,NULL),(19,4,3,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(20,4,77,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(21,4,78,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(22,4,79,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(23,4,80,0,0,0,0,0,0,0,0,0,7,NULL),(24,4,81,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(25,4,82,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(26,4,83,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(27,4,84,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(28,2,78,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-09 14:23:12'),(29,2,78,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-09 14:37:00'),(30,2,78,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-09 14:44:17'),(31,2,78,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(32,8,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(33,8,77,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(34,8,79,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(35,9,77,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-20 13:35:47'),(36,9,77,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-20 13:35:47'),(37,9,81,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-20 13:35:49'),(38,9,77,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-20 13:35:47'),(39,9,81,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-20 13:35:49'),(40,9,82,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-20 13:35:49'),(41,9,77,1,0,2,1,0,0,0,4,0,0,NULL),(42,9,81,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-20 13:36:13'),(43,9,81,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-20 13:36:13'),(44,9,82,2,0,2,0,0,2,0,0,6,0,NULL),(45,9,81,0,0,0,0,5,0,0,0,0,0,NULL),(46,10,1,2,2,1,0,0,0,0,0,0,0,NULL),(47,10,80,0,0,0,0,0,0,0,0,0,0,NULL),(48,10,83,2,0,1,0,0,0,0,0,0,0,NULL),(49,10,79,2,1,2,0,0,0,0,0,0,0,NULL),(50,11,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-20 18:59:55'),(51,11,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-20 18:59:55'),(52,11,2,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(53,11,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-20 19:01:58'),(54,11,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-20 19:02:24'),(55,11,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-20 19:03:37'),(56,11,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-20 19:03:37'),(57,11,3,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(58,11,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-20 19:05:18'),(59,11,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-20 19:05:19'),(60,11,77,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,'2014-02-20 19:05:19'),(61,11,77,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(62,12,80,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),(63,7,2,0,0,0,2,0,0,0,0,0,0,NULL);
/*!40000 ALTER TABLE `character` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `charactercard`
--

DROP TABLE IF EXISTS `charactercard`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `charactercard` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `BaseHandSize` int(11) NOT NULL,
  `BaseLightArmors` int(11) NOT NULL,
  `BaseHeavyArmors` int(11) NOT NULL,
  `BaseWeapons` int(11) NOT NULL,
  `BaseWeaponCards` int(11) NOT NULL,
  `BaseSpellCards` int(11) NOT NULL,
  `BaseArmorCards` int(11) NOT NULL,
  `BaseItemCards` int(11) NOT NULL,
  `BaseAllyCards` int(11) NOT NULL,
  `BaseBlessingCards` int(11) NOT NULL,
  `PossibleHandSize` int(11) NOT NULL,
  `PossibleWeaponCards` int(11) NOT NULL,
  `PossibleSpellCards` int(11) NOT NULL,
  `PossibleArmorCards` int(11) NOT NULL,
  `PossibleItemCards` int(11) NOT NULL,
  `PossibleAllyCards` int(11) NOT NULL,
  `PossibleBlessingCards` int(11) NOT NULL,
  `FavoredCardType` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=85 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `charactercard`
--

LOCK TABLES `charactercard` WRITE;
/*!40000 ALTER TABLE `charactercard` DISABLE KEYS */;
INSERT INTO `charactercard` VALUES (1,'Kyra',5,2,2,1,2,3,2,1,1,6,6,4,5,4,2,2,8,'Blessing'),(2,'Sajan',4,0,0,0,0,0,0,4,3,8,6,3,1,0,6,5,10,'Item'),(3,'Lem',6,1,0,1,1,4,0,2,3,5,6,3,6,1,4,5,6,'Your choice'),(77,'Lini',5,1,0,1,0,6,0,2,3,4,5,1,8,1,4,6,5,'Ally'),(78,'Valeros',4,2,2,2,5,0,3,2,2,3,6,8,0,5,4,4,4,'Weapon'),(79,'Amiri',4,2,1,2,5,0,2,2,2,4,5,8,0,3,5,3,6,'Weapon'),(80,'Ezren',6,0,0,0,1,8,0,3,3,0,8,2,11,1,6,5,0,'Spell'),(81,'Seoni',6,0,0,0,0,3,0,3,4,5,7,1,6,0,6,5,7,'Spell'),(82,'Harsk',5,2,0,2,5,0,1,3,1,5,6,6,2,2,5,4,6,'Weapon'),(83,'Merisiel',5,2,0,1,2,0,1,6,2,4,6,4,1,2,9,3,6,'Item'),(84,'Seelah',4,2,2,2,3,1,3,0,2,6,5,5,3,5,0,4,8,'Armor');
/*!40000 ALTER TABLE `charactercard` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `characterdeck`
--

DROP TABLE IF EXISTS `characterdeck`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `characterdeck` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CharacterId` int(11) NOT NULL,
  `CardId` int(11) NOT NULL,
  `Count` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_characterdeck_partycharacter_id_idx` (`CharacterId`),
  KEY `fk_characterdeck_card_idx` (`CardId`),
  CONSTRAINT `fk_characterdeck_character` FOREIGN KEY (`CharacterId`) REFERENCES `character` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_characterdeck_card` FOREIGN KEY (`CardId`) REFERENCES `card` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=119 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `characterdeck`
--

LOCK TABLES `characterdeck` WRITE;
/*!40000 ALTER TABLE `characterdeck` DISABLE KEYS */;
INSERT INTO `characterdeck` VALUES (7,3,86,1),(8,3,94,1),(10,3,102,1),(11,3,96,1),(13,3,130,2),(14,3,89,1),(15,41,427,1),(16,41,124,2),(17,41,117,2),(18,41,131,1),(19,41,113,1),(20,41,164,1),(21,41,261,1),(22,41,207,1),(23,41,171,1),(24,41,274,1),(25,41,208,1),(26,41,276,1),(27,41,186,1),(28,41,185,1),(29,41,187,1),(30,44,103,1),(31,44,254,1),(32,44,93,1),(33,44,199,1),(34,44,98,1),(35,44,187,1),(36,44,183,1),(37,44,190,1),(38,44,186,1),(39,44,185,1),(40,44,193,1),(41,44,155,1),(42,44,204,1),(43,44,266,1),(44,44,178,1),(45,44,135,1),(46,44,430,1),(47,45,258,2),(48,45,256,1),(49,45,115,1),(50,45,257,1),(51,45,428,1),(52,45,429,1),(53,45,266,1),(54,45,181,2),(55,45,177,1),(56,45,182,1),(57,45,190,1),(58,45,188,1),(59,45,187,1),(60,45,191,1),(61,45,186,1),(62,46,99,1),(63,46,90,1),(64,46,117,1),(65,46,118,2),(66,46,134,1),(67,46,139,1),(68,46,158,1),(70,46,188,1),(71,46,186,1),(72,46,187,1),(73,46,192,3),(74,47,99,1),(77,47,126,1),(78,47,119,1),(79,47,115,1),(80,47,128,2),(81,47,121,2),(83,47,147,1),(84,47,150,1),(85,47,177,1),(86,47,174,1),(87,47,181,1),(88,48,94,1),(90,48,137,1),(91,48,160,1),(92,48,163,1),(93,48,204,1),(95,48,165,2),(96,48,174,1),(97,48,179,1),(98,48,186,1),(99,48,192,3),(100,49,96,1),(101,49,110,1),(102,49,98,1),(103,49,201,1),(104,49,91,1),(105,49,137,1),(106,49,134,1),(107,49,203,1),(108,49,162,1),(109,49,176,1),(110,49,181,1),(111,49,188,1),(112,49,192,3),(113,48,105,1),(114,46,174,1),(115,47,159,1),(116,48,161,1),(117,47,116,1),(118,63,86,1);
/*!40000 ALTER TABLE `characterdeck` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `characterpower`
--

DROP TABLE IF EXISTS `characterpower`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `characterpower` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CharacterId` int(11) NOT NULL,
  `PowerId` int(11) NOT NULL,
  `SelectedPowers` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_characterpower_partycharacter_id_idx` (`CharacterId`),
  KEY `fk_characterpower_power_id_idx` (`PowerId`),
  CONSTRAINT `fk_characterpower_character` FOREIGN KEY (`CharacterId`) REFERENCES `character` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_characterpower_power` FOREIGN KEY (`PowerId`) REFERENCES `power` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `characterpower`
--

LOCK TABLES `characterpower` WRITE;
/*!40000 ALTER TABLE `characterpower` DISABLE KEYS */;
INSERT INTO `characterpower` VALUES (1,23,16,3),(2,18,3,3),(3,25,20,1),(4,25,19,1),(5,3,5,3),(6,27,24,0),(7,27,23,0),(8,41,8,1),(9,44,20,3),(10,45,17,3);
/*!40000 ALTER TABLE `characterpower` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `characterscenario`
--

DROP TABLE IF EXISTS `characterscenario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `characterscenario` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Completed` bit(1) NOT NULL,
  `ScenarioId` int(11) NOT NULL,
  `CharacterId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_characterscenario_scenario_idx` (`ScenarioId`),
  CONSTRAINT `fk_characterscenario_character` FOREIGN KEY (`Id`) REFERENCES `character` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_characterscenario_scenario` FOREIGN KEY (`ScenarioId`) REFERENCES `scenario` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `characterscenario`
--

LOCK TABLES `characterscenario` WRITE;
/*!40000 ALTER TABLE `characterscenario` DISABLE KEYS */;
/*!40000 ALTER TABLE `characterscenario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `characterskill`
--

DROP TABLE IF EXISTS `characterskill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `characterskill` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CharacterId` int(11) NOT NULL,
  `SkillId` int(11) NOT NULL,
  `SelectedAdjustment` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_characterskills_partycharacter_idx` (`CharacterId`),
  KEY `fk_characterskills_skills_idx` (`SkillId`),
  CONSTRAINT `fk_characterskill_character` FOREIGN KEY (`CharacterId`) REFERENCES `character` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_characterskill_skill` FOREIGN KEY (`SkillId`) REFERENCES `skill` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `characterskill`
--

LOCK TABLES `characterskill` WRITE;
/*!40000 ALTER TABLE `characterskill` DISABLE KEYS */;
INSERT INTO `characterskill` VALUES (1,3,1,1),(2,4,1,3),(3,4,4,1),(4,4,6,1),(5,4,7,1),(6,8,11,3),(7,8,13,1),(8,8,16,1),(9,18,11,0),(10,18,13,1),(11,23,46,1),(12,23,48,1),(13,25,57,2),(14,3,18,1),(17,3,19,3),(18,3,24,1),(19,3,21,1),(20,17,1,2),(21,1,1,3),(22,41,25,1),(23,41,29,2),(24,44,56,3),(25,45,54,3),(26,46,1,2),(27,47,46,2),(28,48,62,2),(29,49,37,2);
/*!40000 ALTER TABLE `characterskill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `party`
--

DROP TABLE IF EXISTS `party`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `party` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `PcgUserId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_pcguser_id_idx` (`PcgUserId`),
  CONSTRAINT `fk_party_pcguser` FOREIGN KEY (`PcgUserId`) REFERENCES `pcguser` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `party`
--

LOCK TABLES `party` WRITE;
/*!40000 ALTER TABLE `party` DISABLE KEYS */;
INSERT INTO `party` VALUES (1,'a1',7),(2,'a2qqqaaz',7),(3,'rrrr',7),(4,'z2',7),(5,'myparty',7),(6,'myparty2',7),(7,'q1',7),(8,'a2',7),(9,'Hanne, Johannes, Kim',1),(10,'Number 1',1),(11,'a3',7),(12,'e2',7);
/*!40000 ALTER TABLE `party` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pcguser`
--

DROP TABLE IF EXISTS `pcguser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pcguser` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Email` varchar(200) NOT NULL,
  `Password` varchar(100) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pcguser`
--

LOCK TABLES `pcguser` WRITE;
/*!40000 ALTER TABLE `pcguser` DISABLE KEYS */;
INSERT INTO `pcguser` VALUES (1,'kje@efigame.com','metoo101'),(2,'kje@efigame.com','metoo1'),(3,'abc@abc.com','abc'),(4,'qwe@qwe.qwe','qwe'),(5,'q1@q1.com','q1'),(6,'z1@z1.z1','z1'),(7,'z2@z2.z2','z2');
/*!40000 ALTER TABLE `pcguser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `power`
--

DROP TABLE IF EXISTS `power`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `power` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Text` varchar(500) NOT NULL,
  `Number` int(11) NOT NULL,
  `Dice` int(11) DEFAULT NULL,
  `Adjustment` int(11) DEFAULT NULL,
  `CharacterCardId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_power_charactercard_id_idx` (`CharacterCardId`),
  CONSTRAINT `fk_power_charactercard_id` FOREIGN KEY (`CharacterCardId`) REFERENCES `charactercard` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `power`
--

LOCK TABLES `power` WRITE;
/*!40000 ALTER TABLE `power` DISABLE KEYS */;
INSERT INTO `power` VALUES (1,'Instead of your first exploration on a turn, you may reveal a card with the Divine trait to choose a character at your location. Shuffle 1d4+1 ({format:check} +2) random cards from his discard pile into his deck, then discard the card you revealed.',1,0,0,1),(2,'Add 1d8 ({format:check} +1) with the Magic trait to your check to defeat a bane with the Undead trait.',2,0,0,1),(3,'When you attempt a combat check without playing a weapon, you may use your Dexterity die instead of your Strength die ({format:check} and add the Magic trait) ({format:check} and the Fire trait).',1,NULL,NULL,2),(4,'You may play any number of blessings on your combat check; recharge them instead of discarding them.',2,NULL,NULL,2),(5,'Once per check, you may recharge a card to add 1d4 ({format:check}+1) ({format:check}+2) to a check attempted by another character at your location.',1,NULL,NULL,3),(6,'At the start of your turn, you may exchange 1 card in your hand with 1 card of the same type in your discard pile.',2,NULL,NULL,3),(7,'When you play an ally with the Animal trait, you may recharge it instead of discarding it.',1,NULL,NULL,77),(8,'You may reveal an ally with the Animal trait to add 1d4 ({format:check}+1) ({format:check}+2) to your check.',2,NULL,NULL,77),(9,'You may discard a card to roll d10 instead of your Strength or Dexterity die for any check.',3,NULL,NULL,77),(10,'Add 1d4 ({format:check}+1) ({format:check}+2) to another character\'s combat check at your location.',1,NULL,NULL,78),(11,'When you play a weapon, you may recharge it instead of discarding it.',2,NULL,NULL,78),(12,'You may bury a card from your hand to add 1d10 ({format:check}+1) to your Strength, Melee, or Constitution check.',1,NULL,NULL,79),(13,'You may move at the end of your turn ({format:check} and / or move another character to the location where you end your turn).',2,NULL,NULL,79),(14,'After you play a spell with the Arcane trait, you may examine the top card of your deck; if it\'s a spell, you may put it in your hand.',1,NULL,NULL,80),(15,'If you acquire a card with the Magic trait during an exploration, you may immediately explore again.',2,NULL,NULL,80),(16,'{format:check} Add 1 ({format:check} 2) to your check to recharge a card.',3,NULL,NULL,80),(17,'For your combat check, you may discard a card to roll your Arcane die + 1d6 ({format:check}+1) ({format:check}+2) with the Attack, Fire, and Magic traits. This counts as playing a spell.',1,NULL,NULL,81),(18,'You automatically succeed at your check to recharge a spell ({format:check} or item) with the Arcane trait.',2,NULL,NULL,81),(19,'At the end of your turn, you may examine the top card ({format:check} or bottom card) of your location deck.',1,NULL,NULL,82),(20,'You may recharge a card to add 1d4 ({format:check} +1) ({format:check} +2) to a combat check at another location.',2,NULL,NULL,82),(21,'You may evade your encounter.',1,NULL,NULL,83),(22,'If you are the only character at your location, you may recharge a card to add 1d6 ({format:check} + 1) ({format:check} + 2) to your combat check, or discard it to add an additional 1d6.',2,NULL,NULL,83),(23,'You may discard the top card of your deck to add 1d6 ({format:check} +1) to your check. If the top card was a blessing ({format:check} or spell), recharge it instead of discarding it.',1,NULL,NULL,84),(24,'You may examine the top card of you location deck at the start ({format:check} or end) of your turn. If it\'s a boon, put in on the bottom of the deck.',2,NULL,NULL,84);
/*!40000 ALTER TABLE `power` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `scenario`
--

DROP TABLE IF EXISTS `scenario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `scenario` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `Index` int(11) NOT NULL,
  `AdventureDeckId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_scenario_adventuredeck_idx` (`AdventureDeckId`),
  CONSTRAINT `fk_scenario_adventuredeck` FOREIGN KEY (`AdventureDeckId`) REFERENCES `adventuredeck` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `scenario`
--

LOCK TABLES `scenario` WRITE;
/*!40000 ALTER TABLE `scenario` DISABLE KEYS */;
INSERT INTO `scenario` VALUES (1,'Brigandoom',1,1),(2,'The Poison Pill',2,1),(3,'Black Fang’s Dungeon',3,1),(4,'Attack on Sandpoint',1,2),(5,'Local Heroes',2,2),(6,'Trouble in Sandpoint',3,2),(7,'Approach to Thistletop',4,2),(8,'Thistletop Delve',5,2),(9,'Undead Uprising',1,3),(10,'Crow Bait',2,3),(11,'Foul Misgivings',3,3),(12,'The Cult Exposed',4,3),(13,'Angel in the Tower',5,3),(14,'Them Ogres Ain’t Right',1,4),(15,'The Fort in Peril',2,4),(16,'Here Comes the Flood ',3,4),(17,'Battle at the Dam',4,4),(18,'Into the Mountains',5,4),(19,'Sandpoint Under Siege',1,5),(20,'Jorgenfist',2,5),(21,'The Black Tower',3,5),(22,'Under Jorgenfist',4,5),(23,'The Ancient Library',5,5),(24,'Underneath Sandpoint',1,6),(25,'Rimeskull',2,6),(26,'The Halls of Seduction',3,6),(27,'Thassilonian Sins',4,6),(28,'Into the Runeforge',5,6),(29,'Cabin in the Snow',1,7),(30,'The Road through Xin-Shalast',2,7),(31,'Scaling Mhar Massif',3,7),(32,'Assault on the Pinnacle',4,7),(33,'Into the Eye',5,7);
/*!40000 ALTER TABLE `scenario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `skill`
--

DROP TABLE IF EXISTS `skill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `skill` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `Dice` int(11) NOT NULL,
  `CharacterCardId` int(11) NOT NULL,
  `PossibleAddons` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_charactercard_id_idx` (`CharacterCardId`),
  CONSTRAINT `fk_skill_charactercard` FOREIGN KEY (`CharacterCardId`) REFERENCES `charactercard` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=73 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `skill`
--

LOCK TABLES `skill` WRITE;
/*!40000 ALTER TABLE `skill` DISABLE KEYS */;
INSERT INTO `skill` VALUES (1,'Strength',6,1,4),(3,'Dexterity',4,1,1),(4,'Constitution',6,1,2),(6,'Intelligence',6,1,2),(7,'Wisdom',12,1,4),(9,'Charisma',6,1,2),(10,'Strength',6,2,2),(11,'Dexterity',10,2,4),(13,'Constitution',6,2,2),(15,'Intelligence',6,2,2),(16,'Wisdom',8,2,3),(17,'Charisma',6,2,2),(18,'Strength',4,3,2),(19,'Dexterity',8,3,3),(20,'Constitution',6,3,2),(21,'Intelligence',6,3,2),(23,'Wisdom',6,3,2),(24,'Charisma',10,3,4),(25,'Strength',4,77,2),(26,'Dexterity',6,77,2),(27,'Constitution',8,77,2),(28,'Intelligence',6,77,2),(29,'Wisdom',10,77,4),(30,'Charisma',8,77,3),(31,'Strength',10,78,4),(32,'Dexterity',8,78,2),(33,'Constitution',8,78,4),(34,'Intelligence',6,78,1),(35,'Wisdom',4,78,2),(36,'Charisma',6,78,2),(37,'Strength',12,79,4),(38,'Dexterity',6,79,3),(39,'Consitution',8,79,4),(40,'Intelligence',4,79,1),(41,'Wisdom',6,79,1),(42,'Charisma',6,79,2),(43,'Strength',6,80,1),(44,'Dexterity',6,80,3),(45,'Constitution',4,80,2),(46,'Intelligence',12,80,4),(47,'Wisdom',8,80,2),(48,'Charisma',6,80,3),(49,'Strength',4,81,1),(50,'Dexterity',8,81,3),(51,'Constitution',6,81,2),(52,'Intelligence',6,81,3),(53,'Wisdom',6,81,2),(54,'Charisma',12,81,4),(55,'Strength',6,82,3),(56,'Dexterity',8,82,4),(57,'Constitution',12,82,3),(58,'Intelligence',6,82,1),(59,'Wisdom',6,82,3),(60,'Charisma',4,82,1),(61,'Strength',8,83,3),(62,'Dexterity',12,83,4),(63,'Constitution',6,83,2),(64,'Intelligence',4,83,3),(65,'Wisdom',6,83,1),(66,'Charisma',6,83,2),(67,'Strength',8,84,4),(68,'Dexterity',4,84,1),(69,'Constitution',8,84,3),(70,'Intelligence',4,84,2),(71,'Wisdom',8,84,3),(72,'Charisma',10,84,2);
/*!40000 ALTER TABLE `skill` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subskill`
--

DROP TABLE IF EXISTS `subskill`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `subskill` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  `BaseSkillId` int(11) NOT NULL,
  `Adjustment` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_subskills_skills_id_idx` (`BaseSkillId`),
  CONSTRAINT `fk_subskill_skill` FOREIGN KEY (`BaseSkillId`) REFERENCES `skill` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subskill`
--

LOCK TABLES `subskill` WRITE;
/*!40000 ALTER TABLE `subskill` DISABLE KEYS */;
INSERT INTO `subskill` VALUES (1,'Melee',1,2),(2,'Fortitute',4,3),(3,'Divine',7,2),(4,'Acrobatics',11,2),(5,'Fortitude',13,2),(6,'Knowledge',21,3),(7,'Arcane',24,1),(8,'Diplomacy',24,3),(9,'Divine',24,1),(10,'Knowledge',28,3),(11,'Divine',29,1),(12,'Survival',29,2),(13,'Melee',31,3),(14,'Diplomacy',36,2),(15,'Melee',37,2),(16,'Survival',41,3),(17,'Arcane',46,2),(18,'Knowledge',46,2),(19,'Diplomacy',54,2),(20,'Arcane',54,2),(21,'Ranged',56,3),(22,'Fortitude',57,2),(23,'Perception',59,2),(24,'Survival',59,2),(25,'Acrobatics',62,2),(26,'Disable',62,2),(27,'Stealth',62,2),(28,'Perception',65,2),(29,'Melee',67,2),(30,'Divine',71,2);
/*!40000 ALTER TABLE `subskill` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-03-08 19:09:04
