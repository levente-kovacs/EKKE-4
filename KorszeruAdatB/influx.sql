from(bucket: "mérések")
  |> range(start: -1d)
  |> filter(fn: (r) => r._measurement == "hőmérséklet" and r.város == "Debrecen")
  |> mean()
