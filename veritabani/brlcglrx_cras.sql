-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1:3306
-- Üretim Zamanı: 10 May 2018, 09:07:01
-- Sunucu sürümü: 5.7.19
-- PHP Sürümü: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `brlcglrx_cras`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `adisyonlar`
--

DROP TABLE IF EXISTS `adisyonlar`;
CREATE TABLE IF NOT EXISTS `adisyonlar` (
  `adisyon_id` int(11) NOT NULL AUTO_INCREMENT,
  `masa_id` int(11) DEFAULT NULL,
  `adisyon_urun_id` int(11) DEFAULT NULL,
  `urun_ozellik_adi` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `adisyon_odeme_durumu` int(1) DEFAULT '0',
  PRIMARY KEY (`adisyon_id`),
  KEY `masa_adisyonlar` (`masa_id`),
  KEY `masa_urunler` (`adisyon_urun_id`)
) ENGINE=InnoDB AUTO_INCREMENT=348 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `adisyonlar`
--

INSERT INTO `adisyonlar` (`adisyon_id`, `masa_id`, `adisyon_urun_id`, `urun_ozellik_adi`, `adisyon_odeme_durumu`) VALUES
(58, 24, 32, 'Çift Elma', 1),
(60, 21, 29, '', 0),
(61, 21, 29, '', 0),
(62, 21, 29, '', 0),
(80, 26, 32, 'Çift Elma', 0),
(81, 26, 22, 'Sicak', 0),
(83, 27, 1, '', 0),
(84, 27, 25, '', 0),
(87, 29, 9, '', 0),
(98, 28, 17, 'sade', 0),
(99, 29, 20, '', 0),
(101, 24, 26, '', 1),
(177, 4, 32, 'Seftali', 0),
(179, 4, 32, 'Visne', 0),
(186, 1, 15, '', 0),
(187, 1, 15, '', 0),
(188, 1, 15, '', 0),
(189, 1, 15, '', 0),
(190, 1, 15, '', 0),
(191, 8, 26, '', 1),
(192, 8, 26, '', 1),
(193, 8, 26, '', 1),
(202, 7, 18, '', 0),
(203, 7, 17, 'Sekerli', 0),
(204, 7, 17, 'orta', 0),
(205, 7, 18, '', 0),
(206, 6, 19, '', 0),
(207, 6, 20, '', 0),
(208, 6, 21, '', 0),
(209, 6, 23, '', 0),
(210, 6, 22, 'Sicak', 0),
(211, 6, 22, 'Soguk / buzlu', 0),
(212, 25, 18, '', 0),
(213, 25, 19, '', 0),
(214, 25, 20, '', 0),
(215, 25, 21, '', 0),
(216, 25, 17, 'Sekerli', 0),
(217, 23, 24, '', 0),
(218, 23, 24, '', 0),
(219, 23, 2, '', 0),
(220, 23, 2, '', 0),
(221, 23, 3, '', 0),
(222, 23, 21, '', 0),
(223, 23, 31, 'Çift Elma', 0),
(224, 12, 25, '', 0),
(225, 12, 32, 'Seftali', 0),
(226, 2, 35, '', 1),
(227, 2, 35, '', 1),
(228, 3, 23, '', 1),
(229, 3, 23, '', 1),
(230, 3, 23, '', 1),
(231, 4, 17, 'Çok Şekerli', 1),
(232, 4, 17, 'Çok Şekerli', 1),
(233, 4, 17, 'Çok Şekerli', 1),
(234, 4, 18, '', 1),
(235, 4, 18, '', 1),
(236, 4, 40, 'Blue Mist', 1),
(237, 4, 4, '', 1),
(238, 4, 5, 'Fişna Suyu', 1),
(239, 4, 16, '', 1),
(240, 4, 16, '', 1),
(241, 4, 16, '', 1),
(242, 4, 8, '', 1),
(243, 4, 8, '', 1),
(244, 4, 8, '', 1),
(245, 4, 8, '', 1),
(246, 11, 25, '', 0),
(247, 11, 25, '', 0),
(248, 11, 25, '', 0),
(249, 4, 7, '', 1),
(250, 4, 7, '', 1),
(251, 4, 7, '', 1),
(252, 4, 7, '', 1),
(253, 4, 7, '', 1),
(254, 4, 7, '', 1),
(255, 4, 7, '', 1),
(256, 4, 7, '', 1),
(257, 4, 9, '', 1),
(258, 4, 10, '', 1),
(259, 4, 11, '', 1),
(260, 4, 12, '', 1),
(261, 4, 9, '', 1),
(262, 4, 8, '', 1),
(263, 4, 6, '', 1),
(264, 4, 4, '', 1),
(265, 4, 5, 'Enerji', 1),
(266, 4, 5, 'Enerji', 1),
(267, 4, 26, '', 1),
(268, 4, 25, '', 1),
(269, 4, 24, '', 1),
(270, 4, 23, '', 1),
(271, 4, 40, 'Blue Mist', 1),
(272, 4, 40, 'Double Melon', 1),
(273, 4, 32, 'Şeftali', 1),
(274, 4, 32, 'Çift Elma', 1),
(275, 4, 32, 'Vişne', 1),
(276, 4, 32, 'Cappuccino', 1),
(277, 4, 31, 'Cappuccino', 1),
(278, 4, 31, 'Üzüm', 1),
(279, 4, 31, 'Nane', 1),
(280, 4, 21, '', 1),
(281, 4, 20, '', 1),
(282, 4, 19, '', 1),
(283, 4, 18, '', 1),
(284, 4, 17, 'Çok Şekerli', 1),
(285, 4, 15, '', 1),
(286, 4, 16, '', 1),
(287, 4, 14, '', 1),
(288, 4, 13, '', 1),
(289, 4, 13, '', 1),
(290, 4, 30, '', 1),
(291, 4, 29, '', 1),
(292, 4, 28, '', 1),
(293, 4, 27, '', 1),
(294, 4, 33, '', 1),
(295, 4, 34, '', 1),
(296, 4, 34, '', 1),
(297, 4, 35, '', 1),
(298, 4, 36, '', 1),
(299, 4, 37, '', 1),
(300, 4, 42, '', 1),
(301, 4, 2, '', 1),
(302, 4, 41, '', 1),
(303, 4, 3, '', 1),
(304, 4, 1, '', 1),
(305, 4, 43, '', 1),
(306, 4, 44, '', 1),
(308, 4, 40, 'Blue Mist', 1),
(310, 4, 8, '', 1),
(311, 4, 9, '', 1),
(312, 4, 6, '', 1),
(313, 4, 5, 'Portakal Suyu', 1),
(314, 4, 40, 'Blue Mist', 0),
(315, 4, 40, 'Double Melon', 0),
(316, 4, 23, '', 1),
(317, 4, 25, '', 1),
(318, 4, 40, 'Blue Mist', 1),
(319, 4, 40, 'Double Melon', 1),
(320, 3, 27, '', 1),
(321, 3, 28, '', 1),
(322, 3, 29, '', 1),
(323, 3, 30, '', 1),
(324, 3, 5, 'Portakal Suyu', 1),
(325, 3, 5, 'Enerji', 1),
(326, 3, 8, '', 1),
(327, 3, 7, '', 1),
(328, 3, 5, 'Portakal Suyu', 1),
(329, 3, 12, '', 1),
(330, 3, 31, 'Üzüm', 1),
(331, 3, 31, 'Cappuccino', 1),
(332, 3, 31, 'Yaban Mersini', 1),
(333, 3, 40, 'Blue Mist', 1),
(334, 3, 40, 'Double Melon', 1),
(335, 3, 32, 'Vişne', 1),
(336, 9, 24, '', 1),
(337, 9, 23, '', 1),
(338, 9, 7, '', 1),
(339, 9, 5, 'Portakal Suyu', 1),
(340, 9, 5, 'Enerji', 1),
(341, 9, 6, '', 1),
(342, 9, 7, '', 1),
(343, 9, 40, 'Blue Mist', 1),
(344, 10, 28, '', 0),
(345, 10, 28, '', 0),
(346, 10, 29, '', 0),
(347, 10, 30, '', 0);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `aktarmalar`
--

DROP TABLE IF EXISTS `aktarmalar`;
CREATE TABLE IF NOT EXISTS `aktarmalar` (
  `aktarma_id` int(11) NOT NULL AUTO_INCREMENT,
  `aktarma_masa_id` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `aktarma_aktarilan_masa_id` int(11) NOT NULL,
  `aktarma_personel_id` int(11) NOT NULL,
  `aktarma_tarihi` datetime NOT NULL,
  PRIMARY KEY (`aktarma_id`),
  KEY `personel_id` (`aktarma_personel_id`),
  KEY `aktarilan_id` (`aktarma_aktarilan_masa_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `aktarmalar`
--

INSERT INTO `aktarmalar` (`aktarma_id`, `aktarma_masa_id`, `aktarma_aktarilan_masa_id`, `aktarma_personel_id`, `aktarma_tarihi`) VALUES
(3, 'Salon 5', 10, 5, '2018-05-07 11:51:25'),
(4, 'Salon 5', 10, 5, '2018-05-07 23:59:59'),
(5, 'Salon 10', 9, 5, '2018-05-07 08:37:15'),
(6, 'Salon 9', 30, 5, '2018-05-07 08:37:29'),
(7, 'Loca 10', 9, 5, '2018-05-07 09:05:15'),
(8, 'Salon 9', 10, 5, '2018-05-08 05:17:58'),
(9, 'Salon 10', 9, 5, '2018-05-08 05:39:31'),
(10, 'Salon 9', 4, 13, '2018-05-08 06:00:29'),
(11, 'Salon 10', 9, 13, '2018-05-09 11:06:22');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `aylik_raporlar`
--

DROP TABLE IF EXISTS `aylik_raporlar`;
CREATE TABLE IF NOT EXISTS `aylik_raporlar` (
  `rapor_id` int(11) NOT NULL AUTO_INCREMENT,
  `rapor_ayi` varchar(2) COLLATE utf8_turkish_ci NOT NULL,
  `rapor_yili` int(4) NOT NULL,
  `rapor_urun_id` int(11) NOT NULL,
  `rapor_urun_adet` int(11) NOT NULL,
  PRIMARY KEY (`rapor_id`),
  KEY `aylik_rapor_urun_id` (`rapor_urun_id`)
) ENGINE=InnoDB AUTO_INCREMENT=70 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `aylik_raporlar`
--

INSERT INTO `aylik_raporlar` (`rapor_id`, `rapor_ayi`, `rapor_yili`, `rapor_urun_id`, `rapor_urun_adet`) VALUES
(1, '04', 2018, 31, 21),
(2, '04', 2018, 32, 14),
(3, '04', 2018, 40, 4),
(4, '04', 2018, 15, 3),
(5, '04', 2018, 29, 6),
(6, '04', 2018, 30, 4),
(7, '04', 2018, 43, 2),
(8, '04', 2018, 17, 2),
(9, '04', 2018, 28, 3),
(10, '04', 2018, 27, 7),
(11, '04', 2018, 14, 8),
(12, '04', 2018, 18, 2),
(13, '04', 2018, 21, 16),
(14, '04', 2018, 2, 2),
(15, '04', 2018, 26, 11),
(16, '04', 2018, 3, 5),
(17, '04', 2018, 41, 2),
(18, '04', 2018, 1, 2),
(19, '04', 2018, 13, 3),
(20, '04', 2018, 16, 2),
(21, '04', 2018, 23, 2),
(22, '04', 2018, 24, 2),
(23, '04', 2018, 25, 8),
(24, '04', 2018, 7, 11),
(25, '04', 2018, 6, 3),
(26, '04', 2018, 4, 3),
(27, '04', 2018, 5, 4),
(28, '04', 2018, 8, 10),
(29, '04', 2018, 9, 3),
(30, '04', 2018, 10, 2),
(31, '04', 2018, 11, 2),
(32, '04', 2018, 12, 2),
(33, '04', 2018, 17, 2),
(34, '04', 2018, 17, 2),
(35, '04', 2018, 17, 2),
(36, '04', 2018, 18, 2),
(37, '04', 2018, 18, 2),
(38, '04', 2018, 35, 5),
(39, '04', 2018, 16, 2),
(40, '04', 2018, 16, 2),
(41, '04', 2018, 16, 2),
(42, '04', 2018, 40, 4),
(43, '04', 2018, 4, 3),
(44, '04', 2018, 5, 4),
(45, '04', 2018, 34, 3),
(46, '04', 2018, 20, 1),
(47, '04', 2018, 19, 1),
(48, '04', 2018, 33, 1),
(49, '04', 2018, 36, 1),
(50, '04', 2018, 37, 1),
(51, '04', 2018, 42, 1),
(52, '04', 2018, 44, 1),
(53, '05', 2018, 16, 4),
(54, '05', 2018, 8, 7),
(55, '05', 2018, 7, 8),
(56, '05', 2018, 40, 6),
(57, '05', 2018, 9, 1),
(58, '05', 2018, 6, 2),
(59, '05', 2018, 5, 6),
(60, '05', 2018, 23, 5),
(61, '05', 2018, 25, 1),
(62, '05', 2018, 31, 4),
(63, '05', 2018, 27, 1),
(64, '05', 2018, 28, 1),
(65, '05', 2018, 29, 1),
(66, '05', 2018, 30, 1),
(67, '05', 2018, 12, 1),
(68, '05', 2018, 32, 1),
(69, '05', 2018, 24, 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `hata_loglari`
--

DROP TABLE IF EXISTS `hata_loglari`;
CREATE TABLE IF NOT EXISTS `hata_loglari` (
  `log_id` int(11) NOT NULL AUTO_INCREMENT,
  `log_mesaj` longtext CHARACTER SET utf8 COLLATE utf8_turkish_ci NOT NULL,
  `log_tarih` datetime NOT NULL,
  `log_form_kisim` varchar(200) NOT NULL,
  PRIMARY KEY (`log_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Tablo döküm verisi `hata_loglari`
--

INSERT INTO `hata_loglari` (`log_id`, `log_mesaj`, `log_tarih`, `log_form_kisim`) VALUES
(1, 'Giriş dizesi doğru biçimde değildi.', '2018-05-09 11:41:59', ''),
(2, 'Giriş dizesi doğru biçimde değildi.', '2018-05-09 11:47:58', 'Ürün güncelleme frmAyarlar btnGuncelle_click');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `iadeler`
--

DROP TABLE IF EXISTS `iadeler`;
CREATE TABLE IF NOT EXISTS `iadeler` (
  `iade_id` int(11) NOT NULL AUTO_INCREMENT,
  `iade_urun_id` int(11) NOT NULL,
  `iade_personel_id` int(11) NOT NULL,
  `iade_masa_id` int(11) NOT NULL,
  `iade_tarih` datetime NOT NULL,
  PRIMARY KEY (`iade_id`),
  KEY `iade_urun_id` (`iade_urun_id`),
  KEY `iade_masa_id` (`iade_masa_id`),
  KEY `iade_personel_id` (`iade_personel_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `iadeler`
--

INSERT INTO `iadeler` (`iade_id`, `iade_urun_id`, `iade_personel_id`, `iade_masa_id`, `iade_tarih`) VALUES
(3, 25, 5, 11, '2018-04-24 00:00:00'),
(4, 25, 5, 11, '2018-04-24 00:00:00'),
(5, 25, 5, 11, '2018-04-24 00:00:00'),
(6, 40, 5, 5, '2018-05-07 11:51:01'),
(7, 29, 5, 4, '2018-05-07 03:54:08'),
(8, 45, 5, 1, '2018-05-08 05:17:02'),
(9, 24, 5, 9, '2018-05-08 05:39:38'),
(10, 15, 13, 9, '2018-05-08 06:00:15');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kategoriler`
--

DROP TABLE IF EXISTS `kategoriler`;
CREATE TABLE IF NOT EXISTS `kategoriler` (
  `kategori_id` int(11) NOT NULL AUTO_INCREMENT,
  `kategori_ad` varchar(200) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`kategori_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `kategoriler`
--

INSERT INTO `kategoriler` (`kategori_id`, `kategori_ad`) VALUES
(1, 'Ana Yemekler'),
(2, 'Makarna'),
(3, 'Tatlılar'),
(4, 'Soguk İçecekler'),
(5, 'Sıcak İçecekler'),
(6, 'Nargileler'),
(7, 'Salata'),
(8, 'Alkol');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `kullanici`
--

DROP TABLE IF EXISTS `kullanici`;
CREATE TABLE IF NOT EXISTS `kullanici` (
  `kullanici_id` int(11) NOT NULL AUTO_INCREMENT,
  `kullanici_adi` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `kullanici_sifre` varchar(50) COLLATE utf8_turkish_ci NOT NULL,
  `yetki_id` int(11) NOT NULL,
  `kullanici_aktif` int(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`kullanici_id`),
  KEY `yetki` (`yetki_id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `kullanici`
--

INSERT INTO `kullanici` (`kullanici_id`, `kullanici_adi`, `kullanici_sifre`, `yetki_id`, `kullanici_aktif`) VALUES
(5, 'admin', '1234', 1, 1),
(6, 'birol', '123', 1, 1),
(9, 'garson', '123', 2, 1),
(10, 'şef', '123', 1, 1),
(11, 'demo', 'demo', 1, 0),
(12, 'q23', 'q23', 3, 0),
(13, 'a', 'a', 1, 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `masalar`
--

DROP TABLE IF EXISTS `masalar`;
CREATE TABLE IF NOT EXISTS `masalar` (
  `masa_id` int(11) NOT NULL AUTO_INCREMENT,
  `masa_adi` varchar(255) COLLATE utf8_turkish_ci DEFAULT NULL,
  `masa_tur` int(11) DEFAULT NULL,
  `masa_durum` tinyint(1) NOT NULL,
  PRIMARY KEY (`masa_id`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `masalar`
--

INSERT INTO `masalar` (`masa_id`, `masa_adi`, `masa_tur`, `masa_durum`) VALUES
(1, 'Salon 1', 1, 1),
(2, 'Salon 2', 1, 0),
(3, 'Salon 3', 1, 0),
(4, 'Salon 4', 1, 1),
(5, 'Salon 5', 1, 1),
(6, 'Salon 6', 1, 1),
(7, 'Salon 7', 1, 1),
(8, 'Salon 8', 1, 0),
(9, 'Salon 9', 1, 0),
(10, 'Salon 10', 1, 1),
(11, 'Bahce 1', 2, 1),
(12, 'Bahce 2', 2, 0),
(13, 'Bahce 3', 2, 0),
(14, 'Bahce 4', 2, 0),
(15, 'Bahce 5', 2, 0),
(16, 'Bahce 6', 2, 0),
(17, 'Bahce 7', 2, 0),
(18, 'Bahce 8', 2, 0),
(19, 'Bahce 9', 2, 0),
(20, 'Bahce 10', 2, 0),
(21, 'Loca 1', 3, 0),
(22, 'Loca 2', 3, 0),
(23, 'Loca 3', 3, 1),
(24, 'Loca 4', 3, 0),
(25, 'Loca 5', 3, 1),
(26, 'Loca 6', 3, 0),
(27, 'Loca 7', 3, 0),
(28, 'Loca 8', 3, 0),
(29, 'Loca 9', 3, 0),
(30, 'Loca 10', 3, 0);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `odemeler`
--

DROP TABLE IF EXISTS `odemeler`;
CREATE TABLE IF NOT EXISTS `odemeler` (
  `odeme_id` int(11) NOT NULL AUTO_INCREMENT,
  `odeme_adi` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  PRIMARY KEY (`odeme_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `odemeler`
--

INSERT INTO `odemeler` (`odeme_id`, `odeme_adi`) VALUES
(1, 'Kredi Kartı'),
(2, 'Nakit'),
(3, 'Ticket');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ozellikler`
--

DROP TABLE IF EXISTS `ozellikler`;
CREATE TABLE IF NOT EXISTS `ozellikler` (
  `ozellik_id` int(11) NOT NULL AUTO_INCREMENT,
  `ozellik_adi` varchar(200) COLLATE utf8_turkish_ci DEFAULT NULL,
  `urun_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`ozellik_id`),
  KEY `urun_id` (`urun_id`)
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `ozellikler`
--

INSERT INTO `ozellikler` (`ozellik_id`, `ozellik_adi`, `urun_id`) VALUES
(2, 'Orta Şekerli', 17),
(3, 'Şekerli', 17),
(4, 'Çok Şekerli', 17),
(5, 'Üzüm', 31),
(6, 'Şeftali', 32),
(7, 'Cappuccino', 32),
(8, 'Çift Elma', 32),
(9, 'Vişne', 32),
(12, 'Nane', 31),
(13, 'Cappuccino', 31),
(14, 'Çift Elma', 31),
(15, 'Yaban Mersini', 31),
(16, 'Şeftali', 31),
(17, 'Karpuz', 31),
(18, 'Çilek', 31),
(19, 'Portakal', 31),
(20, 'Limon', 31),
(21, 'Böğürtlen', 31),
(22, 'Sicak', 22),
(23, 'Soguk', 22),
(24, 'Enerji', 5),
(25, 'Fişna Suyu', 5),
(26, 'Portakal Suyu', 5),
(27, 'Sade', 17),
(29, 'Buzlu', 22),
(31, 'Blue Mist', 40),
(32, 'Double Melon', 40),
(33, 'deneme 2', 44);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `raporlar`
--

DROP TABLE IF EXISTS `raporlar`;
CREATE TABLE IF NOT EXISTS `raporlar` (
  `rapor_id` int(11) NOT NULL AUTO_INCREMENT,
  `rapor_tarih` date NOT NULL,
  `rapor_urun_id` int(11) NOT NULL,
  `rapor_urun_adet` int(11) NOT NULL,
  PRIMARY KEY (`rapor_id`),
  KEY `rapor_urun_id` (`rapor_urun_id`)
) ENGINE=InnoDB AUTO_INCREMENT=113 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `raporlar`
--

INSERT INTO `raporlar` (`rapor_id`, `rapor_tarih`, `rapor_urun_id`, `rapor_urun_adet`) VALUES
(1, '2018-04-09', 25, 7),
(2, '2018-04-09', 7, 2),
(3, '2018-04-09', 11, 2),
(4, '2018-04-09', 12, 1),
(5, '2018-04-09', 9, 2),
(6, '2018-04-09', 8, 5),
(7, '2018-04-09', 4, 2),
(8, '2018-04-09', 5, 2),
(9, '2018-04-10', 28, 2),
(10, '2018-04-10', 14, 7),
(11, '2018-04-10', 24, 1),
(12, '2018-04-10', 32, 4),
(13, '2018-04-10', 18, 8),
(14, '2018-04-10', 17, 3),
(15, '2018-04-10', 31, 2),
(16, '2018-04-10', 20, 1),
(17, '2018-04-24', 31, 2),
(18, '2018-04-24', 32, 4),
(19, '2018-04-24', 40, 5),
(20, '2018-04-24', 15, 2),
(21, '2018-04-24', 29, 5),
(22, '2018-04-24', 30, 3),
(23, '2018-04-24', 43, 1),
(24, '2018-04-24', 17, 3),
(25, '2018-04-24', 28, 2),
(26, '2018-04-24', 27, 6),
(27, '2018-04-24', 14, 7),
(28, '2018-04-24', 18, 8),
(29, '2018-04-24', 21, 15),
(30, '2018-04-24', 2, 1),
(31, '2018-04-24', 26, 4),
(32, '2018-04-24', 3, 4),
(33, '2018-04-24', 41, 1),
(34, '2018-04-24', 1, 1),
(35, '2018-04-24', 13, 2),
(36, '2018-04-24', 16, 2),
(37, '2018-04-24', 23, 4),
(38, '2018-04-24', 24, 1),
(39, '2018-04-24', 25, 7),
(40, '2018-04-24', 7, 2),
(41, '2018-04-24', 6, 2),
(42, '2018-04-24', 4, 2),
(43, '2018-04-24', 5, 2),
(44, '2018-04-24', 8, 5),
(45, '2018-04-24', 9, 2),
(46, '2018-04-24', 10, 1),
(47, '2018-04-24', 11, 1),
(48, '2018-04-24', 12, 1),
(49, '2018-04-27', 35, 2),
(50, '2018-04-29', 8, 5),
(51, '2018-04-29', 7, 2),
(52, '2018-04-29', 26, 4),
(53, '2018-04-29', 40, 5),
(54, '2018-04-29', 4, 2),
(55, '2018-04-29', 5, 2),
(56, '2018-04-29', 9, 2),
(57, '2018-04-29', 10, 1),
(58, '2018-04-29', 11, 1),
(59, '2018-04-29', 12, 1),
(60, '2018-04-29', 6, 1),
(61, '2018-04-29', 25, 1),
(62, '2018-04-29', 24, 1),
(63, '2018-04-29', 23, 4),
(64, '2018-04-29', 32, 4),
(65, '2018-04-29', 31, 2),
(66, '2018-04-29', 21, 1),
(67, '2018-04-29', 20, 1),
(68, '2018-04-29', 19, 1),
(69, '2018-04-29', 18, 1),
(70, '2018-04-29', 17, 1),
(71, '2018-04-29', 15, 1),
(72, '2018-04-29', 16, 2),
(73, '2018-04-29', 14, 1),
(74, '2018-04-29', 13, 2),
(75, '2018-04-29', 30, 1),
(76, '2018-04-29', 29, 1),
(77, '2018-04-29', 28, 1),
(78, '2018-04-29', 27, 1),
(79, '2018-04-29', 33, 1),
(80, '2018-04-29', 34, 1),
(81, '2018-04-29', 35, 1),
(82, '2018-04-29', 36, 1),
(83, '2018-04-29', 37, 1),
(84, '2018-04-29', 42, 1),
(85, '2018-04-29', 2, 1),
(86, '2018-04-29', 41, 1),
(87, '2018-04-29', 3, 1),
(88, '2018-04-29', 1, 1),
(89, '2018-04-29', 43, 1),
(90, '2018-04-29', 44, 1),
(91, '2018-05-07', 16, 2),
(92, '2018-05-07', 8, 5),
(93, '2018-05-07', 7, 2),
(94, '2018-05-07', 40, 5),
(95, '2018-05-07', 9, 1),
(96, '2018-05-07', 6, 1),
(97, '2018-05-07', 5, 2),
(98, '2018-05-07', 23, 4),
(99, '2018-05-07', 25, 1),
(100, '2018-05-07', 27, 1),
(101, '2018-05-07', 28, 1),
(102, '2018-05-07', 29, 1),
(103, '2018-05-07', 30, 1),
(104, '2018-05-07', 12, 1),
(105, '2018-05-07', 31, 2),
(106, '2018-05-07', 32, 1),
(107, '2018-05-09', 24, 1),
(108, '2018-05-09', 23, 1),
(109, '2018-05-09', 7, 2),
(110, '2018-05-09', 5, 2),
(111, '2018-05-09', 6, 1),
(112, '2018-05-09', 40, 1);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `satislar`
--

DROP TABLE IF EXISTS `satislar`;
CREATE TABLE IF NOT EXISTS `satislar` (
  `satis_id` int(11) NOT NULL AUTO_INCREMENT,
  `satis_toplam_fiyat` decimal(15,2) NOT NULL,
  `satis_masa_id` int(11) NOT NULL,
  `satis_odeme_turu` int(11) NOT NULL,
  `satis_tarih` datetime NOT NULL,
  PRIMARY KEY (`satis_id`),
  KEY `odeme_turu` (`satis_odeme_turu`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `satislar`
--

INSERT INTO `satislar` (`satis_id`, `satis_toplam_fiyat`, `satis_masa_id`, `satis_odeme_turu`, `satis_tarih`) VALUES
(2, '160.00', 2, 2, '2018-04-09 00:00:00'),
(3, '100.00', 2, 1, '2018-04-09 00:00:00'),
(4, '100.00', 3, 3, '2018-04-09 00:00:00'),
(5, '200.00', 9, 2, '2018-04-09 00:00:00'),
(6, '85.00', 6, 1, '2018-04-10 00:00:00'),
(7, '188.00', 9, 2, '2018-04-10 00:00:00'),
(8, '4.00', 5, 2, '2018-04-10 00:00:00'),
(9, '100.00', 1, 2, '2018-04-24 00:00:00'),
(10, '75.00', 1, 2, '2018-04-24 00:00:00'),
(11, '50.00', 1, 2, '2018-04-24 00:00:00'),
(12, '25.00', 1, 2, '2018-04-24 00:00:00'),
(13, '25.00', 1, 2, '2018-04-24 00:00:00'),
(14, '25.00', 1, 2, '2018-04-24 00:00:00'),
(15, '75.00', 1, 2, '2018-04-24 00:00:00'),
(16, '25.00', 1, 2, '2018-04-24 00:00:00'),
(17, '25.00', 1, 2, '2018-04-24 00:00:00'),
(18, '165.00', 1, 2, '2018-04-24 00:00:00'),
(19, '351.00', 1, 2, '2018-04-24 00:00:00'),
(20, '845.00', 1, 2, '2018-04-24 00:00:00'),
(21, '143.50', 2, 2, '2018-04-24 00:00:00'),
(22, '620.90', 2, 2, '2018-04-24 00:00:00'),
(23, '39.00', 3, 2, '2018-04-24 00:00:00'),
(24, '15.00', 4, 2, '2018-04-24 00:00:00'),
(25, '150.00', 9, 1, '2018-04-24 00:00:00'),
(26, '350.00', 3, 2, '2018-05-01 00:00:00'),
(27, '31.00', 4, 3, '2018-04-27 00:00:00'),
(28, '28.00', 2, 3, '2018-04-27 00:00:00'),
(29, '45.00', 5, 1, '2018-04-29 00:00:00'),
(30, '100.00', 9, 3, '2018-04-29 00:00:00'),
(31, '80.00', 10, 3, '2018-04-29 00:00:00'),
(32, '140.00', 10, 1, '2018-04-29 00:00:00'),
(33, '15.00', 8, 3, '2018-04-29 00:00:00'),
(34, '1168.40', 9, 2, '2018-04-29 00:00:00'),
(35, '325.00', 10, 2, '2018-05-07 11:51:44'),
(36, '110.00', 10, 2, '2018-05-07 10:04:22'),
(37, '405.00', 3, 1, '2018-05-07 10:26:40'),
(38, '175.00', 9, 3, '2018-05-09 11:06:27');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `urunler`
--

DROP TABLE IF EXISTS `urunler`;
CREATE TABLE IF NOT EXISTS `urunler` (
  `urun_id` int(11) NOT NULL AUTO_INCREMENT,
  `urun_adi` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `urun_fiyat` decimal(15,2) DEFAULT NULL,
  `kategori_id` int(11) DEFAULT NULL,
  `urun_ozellik` tinyint(1) NOT NULL DEFAULT '0',
  `urun_aktif` int(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`urun_id`),
  KEY `kategori_id` (`kategori_id`)
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `urunler`
--

INSERT INTO `urunler` (`urun_id`, `urun_adi`, `urun_fiyat`, `kategori_id`, `urun_ozellik`, `urun_aktif`) VALUES
(1, 'Alfredo Penne', '18.00', 1, 0, 1),
(2, 'Köri soslu Tavuk', '18.50', 1, 0, 1),
(3, 'Hamburger', '15.50', 1, 0, 1),
(4, 'Jack Daniels', '25.00', 8, 0, 1),
(5, 'Absolut', '25.00', 8, 1, 1),
(6, 'Chivas Regal', '25.00', 8, 0, 1),
(7, 'Sheridan\'s', '20.00', 8, 0, 1),
(8, 'Jagermeister Shot', '15.00', 8, 0, 1),
(9, 'Absolut Shot', '25.00', 8, 0, 1),
(10, 'Jack Daniels Shot', '25.00', 8, 0, 1),
(11, 'Chivas Regal Shot', '25.00', 8, 0, 1),
(12, 'Captain Morgan Cin', '25.00', 8, 0, 1),
(13, 'Sezar Salata\r\n', '20.50', 7, 0, 1),
(14, 'Hardal Soslu Biftek Salata', '20.00', 7, 0, 1),
(15, 'Ton Balıklı Salata', '14.00', 7, 0, 1),
(16, 'Harvard Salata', '15.00', 7, 0, 1),
(17, 'Türk Kahvesi', '5.00', 5, 1, 1),
(18, 'Filtre Kahve', '8.00', 5, 0, 1),
(19, 'Kapiçino', '5.00', 5, 0, 1),
(20, 'Ihlamur', '4.00', 5, 0, 1),
(21, 'Çay', '3.00', 5, 0, 1),
(22, 'Su', '2.00', 4, 1, 1),
(23, 'Sprite', '5.00', 4, 0, 1),
(24, 'Coca Cola', '5.00', 4, 0, 1),
(25, 'İce Tea', '5.00', 4, 0, 1),
(26, 'İce Latte', '5.00', 4, 0, 1),
(27, 'Baklava', '10.00', 3, 0, 1),
(28, 'İmam Bayıldı', '15.00', 3, 0, 1),
(29, 'Künefe', '13.00', 3, 0, 1),
(30, 'Sufle', '12.00', 3, 0, 1),
(31, 'Al Fakher', '25.00', 6, 1, 1),
(32, 'Al Nakhla', '30.00', 6, 1, 1),
(33, 'Alfredo Penne', '15.00', 2, 0, 1),
(34, 'Napoliten Spaghetti', '16.00', 2, 0, 1),
(35, 'Tavuklu Noddle', '14.00', 2, 0, 1),
(36, 'Biftekli Fettucini', '17.00', 2, 0, 1),
(37, 'Bolonez Spaghetti', '16.00', 2, 0, 1),
(40, 'Starbuzz', '50.00', 6, 1, 1),
(41, 'Tavuk Izgara', '35.40', 1, 0, 1),
(42, 'Ton Balıklı ', '22.00', 2, 0, 1),
(43, 'deneme ürünü', '32.00', 1, 0, 0),
(44, 'deneme ürünü 2', '33.00', 1, 1, 0),
(45, 'DENEME ÜRÜNÜ 3,. +@', '123.35', 1, 0, 0),
(48, '', '1234.00', NULL, 0, 1),
(49, '3', '2.00', 2, 0, 0);

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `yetkiler`
--

DROP TABLE IF EXISTS `yetkiler`;
CREATE TABLE IF NOT EXISTS `yetkiler` (
  `yetki_id` int(11) NOT NULL AUTO_INCREMENT,
  `yetki_adi` varchar(255) COLLATE utf8_turkish_ci NOT NULL,
  `yetki_seviyesi` tinyint(2) NOT NULL,
  PRIMARY KEY (`yetki_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_turkish_ci;

--
-- Tablo döküm verisi `yetkiler`
--

INSERT INTO `yetkiler` (`yetki_id`, `yetki_adi`, `yetki_seviyesi`) VALUES
(1, 'Müdür', 10),
(2, 'Garson', 5),
(3, 'Şef', 7);

--
-- Dökümü yapılmış tablolar için kısıtlamalar
--

--
-- Tablo kısıtlamaları `adisyonlar`
--
ALTER TABLE `adisyonlar`
  ADD CONSTRAINT `masa_adisyonlar` FOREIGN KEY (`masa_id`) REFERENCES `masalar` (`masa_id`),
  ADD CONSTRAINT `masa_urunler` FOREIGN KEY (`adisyon_urun_id`) REFERENCES `urunler` (`urun_id`);

--
-- Tablo kısıtlamaları `aktarmalar`
--
ALTER TABLE `aktarmalar`
  ADD CONSTRAINT `aktarilan_id` FOREIGN KEY (`aktarma_aktarilan_masa_id`) REFERENCES `masalar` (`masa_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `personel_id` FOREIGN KEY (`aktarma_personel_id`) REFERENCES `kullanici` (`kullanici_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Tablo kısıtlamaları `aylik_raporlar`
--
ALTER TABLE `aylik_raporlar`
  ADD CONSTRAINT `aylik_rapor_urun_id` FOREIGN KEY (`rapor_urun_id`) REFERENCES `urunler` (`urun_id`) ON DELETE CASCADE;

--
-- Tablo kısıtlamaları `iadeler`
--
ALTER TABLE `iadeler`
  ADD CONSTRAINT `iade_masa_id` FOREIGN KEY (`iade_masa_id`) REFERENCES `masalar` (`masa_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `iade_personel_id` FOREIGN KEY (`iade_personel_id`) REFERENCES `kullanici` (`kullanici_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `iade_urun_id` FOREIGN KEY (`iade_urun_id`) REFERENCES `urunler` (`urun_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Tablo kısıtlamaları `kullanici`
--
ALTER TABLE `kullanici`
  ADD CONSTRAINT `yetki` FOREIGN KEY (`yetki_id`) REFERENCES `yetkiler` (`yetki_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Tablo kısıtlamaları `ozellikler`
--
ALTER TABLE `ozellikler`
  ADD CONSTRAINT `ozellikler_ibfk_1` FOREIGN KEY (`urun_id`) REFERENCES `urunler` (`urun_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Tablo kısıtlamaları `raporlar`
--
ALTER TABLE `raporlar`
  ADD CONSTRAINT `rapor_urun_id` FOREIGN KEY (`rapor_urun_id`) REFERENCES `urunler` (`urun_id`) ON DELETE CASCADE;

--
-- Tablo kısıtlamaları `satislar`
--
ALTER TABLE `satislar`
  ADD CONSTRAINT `odeme_turu` FOREIGN KEY (`satis_odeme_turu`) REFERENCES `odemeler` (`odeme_id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Tablo kısıtlamaları `urunler`
--
ALTER TABLE `urunler`
  ADD CONSTRAINT `urunler_ibfk_1` FOREIGN KEY (`kategori_id`) REFERENCES `kategoriler` (`kategori_id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
