# Laboration2App

Öppna pdf filen för att se vad laborationen gick ut på.

---------------------------------------------------------------------------------------
Boundary system
---------------------------------------------------------------------------------------

The coordinants were set to:

(-100 <= x-axis < 100)
(-100 <= y-axis < 100)
(-100 <= z-axis < 100)

Other properties such as the width, height, length and radius were set to:

(1 <= width < 11)
(1 <= height < 11)
(1 <= length < 11)
(1 <= radius < 6)

This was to ensure that the various objects maintained a reasonable size

---------------------------------------------------------------------------------------
Random number generator: rng
---------------------------------------------------------------------------------------

A random number generator (RNG) that cycles between whole numbers (integers)
was chosen:

rng.Next(-100, 101)

I also considered using:

(float)rng.NextDouble * 100f * (rng.Next(-1, 1) == 0 ? 1f : -1f)

However, I felt that the readability would ultimately suffer if I were I to
implement the latter option.
