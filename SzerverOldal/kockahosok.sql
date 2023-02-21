-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 07, 2021 at 06:06 PM
-- Server version: 10.4.16-MariaDB
-- PHP Version: 7.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `kockahosok`
--

-- --------------------------------------------------------

--
-- Table structure for table `felhasznalok`
--

CREATE TABLE `felhasznalok` (
  `felhnev` varchar(50) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `email` varchar(100) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `jelszo` varchar(128) COLLATE utf8mb4_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `felhasznalok`
--

INSERT INTO `felhasznalok` (`felhnev`, `email`, `jelszo`) VALUES
('teszt', 'teszt@gmail.com', '202cb962ac59075b964b07152d234b70');

-- --------------------------------------------------------

--
-- Table structure for table `palyak`
--

CREATE TABLE `palyak` (
  `palyaid` int(11) NOT NULL,
  `vilag` int(11) NOT NULL,
  `palya` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `palyak`
--

INSERT INTO `palyak` (`palyaid`, `vilag`, `palya`) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 1, 3),
(4, 1, 4),
(5, 1, 5),
(6, 1, 6);

-- --------------------------------------------------------

--
-- Table structure for table `ranglista`
--

CREATE TABLE `ranglista` (
  `email` varchar(100) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `palyaid` int(11) NOT NULL,
  `pontok` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Dumping data for table `ranglista`
--

INSERT INTO `ranglista` (`email`, `palyaid`, `pontok`) VALUES
('teszt@gmail.com', 1, 600),
('teszt@gmail.com', 2, 220),
('teszt@gmail.com', 3, 300),
('teszt@gmail.com', 4, 300),
('teszt@gmail.com', 5, 500),
('teszt@gmail.com', 6, 600);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `felhasznalok`
--
ALTER TABLE `felhasznalok`
  ADD PRIMARY KEY (`email`);

--
-- Indexes for table `palyak`
--
ALTER TABLE `palyak`
  ADD PRIMARY KEY (`palyaid`);

--
-- Indexes for table `ranglista`
--
ALTER TABLE `ranglista`
  ADD PRIMARY KEY (`email`,`palyaid`),
  ADD KEY `palyaid` (`palyaid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `palyak`
--
ALTER TABLE `palyak`
  MODIFY `palyaid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `ranglista`
--
ALTER TABLE `ranglista`
  ADD CONSTRAINT `ranglista_ibfk_2` FOREIGN KEY (`palyaid`) REFERENCES `palyak` (`palyaid`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `ranglista_ibfk_3` FOREIGN KEY (`email`) REFERENCES `felhasznalok` (`email`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
