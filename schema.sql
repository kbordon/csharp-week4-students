-- ---
-- Globals
-- ---

-- SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
-- SET FOREIGN_KEY_CHECKS=0;

-- ---
-- Table 'students'
--
-- ---

DROP TABLE IF EXISTS `students`;

CREATE TABLE `students` (
  `student_id` INT NULL AUTO_INCREMENT DEFAULT NULL,
  `name` VARCHAR(255) NULL DEFAULT NULL,
  `registerdate` DATETIME NULL DEFAULT NULL,
  `department_id` INT NULL DEFAULT NULL,
  PRIMARY KEY (`student_id`)
);

-- ---
-- Table 'courses'
--
-- ---

DROP TABLE IF EXISTS `courses`;

CREATE TABLE `courses` (
  `course_id` INT NULL AUTO_INCREMENT DEFAULT NULL,
  `name` VARCHAR(255) NULL DEFAULT NULL,
  `department_id` INT NULL DEFAULT NULL,
  PRIMARY KEY (`course_id`)
);

-- ---
-- Table 'courses_students'
--
-- ---

DROP TABLE IF EXISTS `courses_students`;

CREATE TABLE `courses_students` (
  `course_id` INT NULL DEFAULT NULL,
  `student_id` INT NULL DEFAULT NULL,
  `grade` INT NULL DEFAULT NULL,
  `complete` BOOLEAN NULL DEFAULT 0
);

-- ---
-- Table 'departments'
--
-- ---

DROP TABLE IF EXISTS `departments`;

CREATE TABLE `departments` (
  `department_id` INT NULL AUTO_INCREMENT DEFAULT NULL,
  `name` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`department_id`)
);

-- ---
-- Foreign Keys
-- ---

ALTER TABLE `students` ADD FOREIGN KEY (department_id) REFERENCES `departments` (`department_id`)  ON UPDATE CASCADE;
ALTER TABLE `courses` ADD FOREIGN KEY (department_id) REFERENCES `departments` (`department_id`)  ON UPDATE CASCADE;
ALTER TABLE `courses_students` ADD FOREIGN KEY (course_id) REFERENCES `courses` (`course_id`);
ALTER TABLE `courses_students` ADD FOREIGN KEY (student_id) REFERENCES `students` (`student_id`) ;

-- ---
-- Table Properties
-- ---

-- ALTER TABLE `students` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `courses` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `courses_students` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `departments` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ---
-- Test Data
-- ---

-- INSERT INTO `students` (`student_id`,`name`,`registerdate`,`department_id`) VALUES
-- ('','','','');
-- INSERT INTO `courses` (`course_id`,`name`,`department_id`) VALUES
-- ('','','');
-- INSERT INTO `courses_students` (`course_id`,`student_id`,`grade`,`complete`) VALUES
-- ('','','','');
-- INSERT INTO `departments` (`department_id`,`name`) VALUES
-- ('','');
