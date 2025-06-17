SELECT mean("hőmérséklet") FROM "időjárás" WHERE "város"='Szeged' AND time > now() - 7d GROUP BY time(1h);
