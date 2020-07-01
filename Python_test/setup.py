from distutils.core import setup
from setuptools import find_packages

setup(
    name='cool+math3',
    packages=find_packages(exclude=['*.test','.test.*','test']),
    version='o.o.1',
    long_description='cool',
    author='missingdays',

    url='',
    download_url=''
)