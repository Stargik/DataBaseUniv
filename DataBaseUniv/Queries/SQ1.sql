SELECT * 
FROM Teachers
WHERE @P_CC < (SELECT COUNT(Id) 
			   FROM Classes 
			   WHERE Classes.TeacherId = Teachers.Id)
