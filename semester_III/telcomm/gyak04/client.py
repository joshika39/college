from socket import socket, AF_INET, SOCK_STREAM, timeout, SOL_SOCKET, SO_REUSEADDR
import struct
import sys

TCP_IP = "localhost"
TCP_PORT = int(sys.argv[1])
BUFFER_SIZE = 1024
packer = struct.Struct('I I 1s')  # int, int, char[1]
server_addr = (TCP_IP, TCP_PORT)

with socket.socket(socket.AF_INET, socket.SOCK_DGRAM) as client:
    client.connect(server_addr)
    num1 = input("Enter a number:")
    op = input("Enter an operator:")
    num2 = input("Enter another number:")

    values = (int(num1), int(num2), op.encode())
    packed_data = packer.pack(*values)
    sent = client.sendto(packed_data, server_addr)
    data, address = client.recvfrom(4096)

    print("Result:", data)
