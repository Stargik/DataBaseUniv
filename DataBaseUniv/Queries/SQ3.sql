SELECT DISTINCT Classroom
FROM Classes
WHERE @P_TC >= (SELECT COUNT(Id)
				FROM Tasks 
				WHERE Tasks.CourceId = Classes.CourceId)
