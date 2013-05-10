import csv
# Create Fibonacci numbers list
fNumbers=[1,1]
for i in range(2, 100):
    fNumbers.append(fNumbers[i-2]+fNumbers[i-1])
# Write to file with Golder ratio values
with open('result.csv', 'wb') as csvfile:
    fgWriter = csv.writer(csvfile, delimiter=',', quotechar='"', quoting=csv.QUOTE_MINIMAL)
    fgWriter.writerow(['index', 'fibonacci', 'golden ratio'])
    for i in range(1, 100):
        fgWriter.writerow([i-1] + [fNumbers[i-1]] + [float(fNumbers[i-1])/float(fNumbers[i])])
print "Finished"