USE dental_maintenance;
DELIMITER //
CREATE FUNCTION fn_age_years(birth_date DATE,on_date DATE) RETURNS INT DETERMINISTIC
BEGIN
 IF birth_date IS NULL OR on_date IS NULL OR birth_date>on_date THEN RETURN NULL; END IF;
 RETURN TIMESTAMPDIFF(YEAR,birth_date,on_date)-(DATE_FORMAT(on_date,'%m%d')<DATE_FORMAT(birth_date,'%m%d'));
END//
DELIMITER ;