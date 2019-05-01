SELECT
  mc.CountryCode,
  COUNT(mc.MountainId) AS MountainRanges
FROM Countries AS c
INNER JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
WHERE c.CountryName IN ('United States', 'Bulgaria', 'Russia')
GROUP BY mc.CountryCode