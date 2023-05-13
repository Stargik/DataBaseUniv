SELECT DISTINCT *
FROM Tasks
WHERE Tasks.CourceId IN 
			   (SELECT Classes.CourceId
			    FROM Classes
				WHERE Classes.TeacherId IN
										 (SELECT Id
										  FROM Teachers
										  WHERE Teachers.Email = @P_TE))