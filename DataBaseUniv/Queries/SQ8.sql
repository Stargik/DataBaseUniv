SELECT DISTINCT *
FROM Teachers AS T1
WHERE NOT EXISTS
	((SELECT CS.Id
	 FROM Classes AS CS
	 WHERE @P_TC <= (SELECT COUNT(Id)
					FROM Tasks
					WHERE Tasks.CourceId = CS.Id))
					EXCEPT
					(SELECT C2.CourceId
					FROM Classes AS C2
					WHERE C2.TeacherId = T1.Id))