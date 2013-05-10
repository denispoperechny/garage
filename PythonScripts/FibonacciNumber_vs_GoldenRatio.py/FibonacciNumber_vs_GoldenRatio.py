import csv
array=[1,1]
for i in range(2, 100):
    a=array[i-2]
    b=array[i-1]
    array.append(a+b)
with open('result.csv', 'wb') as csvfile:
    spamwriter = csv.writer(csvfile, delimiter=',', quotechar='"', quoting=csv.QUOTE_MINIMAL)
    spamwriter.writerow(['index', 'fibonacci', 'golden ratio'])
    for i in range(1, 100):
        spamwriter.writerow([i-1] + [array[i-1]] + [float(array[i-1])/float(array[i])])
print "Finished"