SELECT DISTINCT *
FROM Teachers AS T1
WHERE NOT EXISTS 
	 (SELECT C1.CourceId
		   FROM Classes AS C1
		   WHERE C1.TeacherId IN 
				(SELECT T2.Id
				 FROM Teachers AS T2
				 WHERE T2.Email = @P_TE) AND C1.CourceId NOT IN
					  (SELECT C2.CourceId
					   FROM Classes AS C2
					   WHERE C2.TeacherId = T1.Id))