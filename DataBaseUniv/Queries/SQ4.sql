SELECT DISTINCT *
FROM Cources
WHERE Cources.Id IN
				(SELECT CourceId
				 FROM Classes 
				 WHERE Classes.TeacherId IN 
										(SELECT Id 
										 FROM Teachers
										 WHERE @P_CC = (SELECT COUNT(Id) 
														FROM Classes AS C2
														WHERE C2.TeacherId = Teachers.Id)))