import struct
import sys

if len(sys.argv) < 3:
    print("Usage example: python", sys.argv[0], "c9si")
    exit(1)

headerInfo = {'s': b'987654321', 'i': 42, 'f': 128.16, '?': True, 'c': b'H'}

i = sys.argv[2]

print(i)
packer = struct.Struct(i)
i = i.replace("9s", "s")

with open(sys.argv[1], 'wb') as f:
    row = [headerInfo[x] for x in i]
    print(row)
    f.write(packer.pack(*row))

