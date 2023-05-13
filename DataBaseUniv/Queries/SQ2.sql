SELECT *
FROM Cources
WHERE Cources.LevelId IN (SELECT Id 
						 FROM Levels
						 WHERE Levels.Status = @P_LSTATUS)
