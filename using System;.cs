import 'package:flutter/material.dart';

void main() {
  runApp(const CalculatorApp());
}

class CalculatorApp extends StatelessWidget {
  const CalculatorApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Calculadora Básica',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: const CalculatorPage(),
    );
  }
}

class CalculatorPage extends StatefulWidget {
  const CalculatorPage({super.key});

  @override
  _CalculatorPageState createState() => _CalculatorPageState();
}

class _CalculatorPageState extends State<CalculatorPage> {
  String _output = '0';
  String _currentInput = '';
  String _operator = '';

  void _clear() {
    setState(() {
      _output = '0';
      _currentInput = '';
      _operator = '';
    });
  }

  void _append(String value) {
    setState(() {
      _currentInput += value;
    });
  }

  void _setOperator(String operator) {
    setState(() {
      _operator = operator;
      _currentInput = '';
    });
  }

  void _calculate() {
    double num1 = double.parse(_output);
    double num2 = double.parse(_currentInput);
    double result = 0;

    switch (_operator) {
      case '+':
        result = num1 + num2;
        break;
      case '-':
        result = num1 - num2;
        break;
      case '*':
        result = num1 * num2;
        break;
      case '/':
        if (num2 == 0) {
          _output = 'Error: División por cero';
        } else {
          result = num1 / num2;
        }
        break;
      default:
        _output = 'Operador inválido';
    }

    setState(() {
      _output = result.toString();
      _currentInput = '';
      _operator = '';
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Calculadora Básica'),
      ),
      body: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Text(
            _output,
            style: const TextStyle(fontSize: 36),
          ),
          Text(
            _currentInput,
            style: const TextStyle(fontSize: 24),
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              ElevatedButton(
                onPressed: _clear,
                child: const Text('C'),
              ),
              ElevatedButton(
                onPressed: () => _append('7'),
                child: const Text('7'),
              ),
              ElevatedButton(
                onPressed: () => _append('8'),
                child: const Text('8'),
              ),
              ElevatedButton(
                onPressed: () => _append('9'),
                child: const Text('9'),
              ),
            ],
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              ElevatedButton(
                onPressed: () => _append('4'),
                child: const Text('4'),
              ),
              ElevatedButton(
                onPressed: () => _append('5'),
                child: const Text('5'),
              ),
              ElevatedButton(
                onPressed: () => _append('6'),
                child: const Text('6'),
              ),
              ElevatedButton(
                onPressed: () => _setOperator('+'),
                child: const Text('+'),
              ),
            ],
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              ElevatedButton(
                onPressed: () => _append('1'),
                child: const Text('1'),
              ),
              ElevatedButton(
                onPressed: () => _append('2'),
                child: const Text('2'),
              ),
              ElevatedButton(
                onPressed: () => _append('3'),
                child: const Text('3'),
              ),
              ElevatedButton(
                onPressed: () => _setOperator('-'),
                child: const Text('-'),
              ),
            ],
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              ElevatedButton(
                onPressed: () => _append('0'),
                child: const Text('0'),
              ),
              ElevatedButton(
                onPressed: () => _append('.'),
                child: const Text('.'),
              ),
              ElevatedButton(
                onPressed: _calculate,
                child: const Text('='),
              ),
              ElevatedButton(
                onPressed: () => _setOperator('*'),
                child: const Text('x'),
              ),
            ],
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              ElevatedButton(
                onPressed: () => _setOperator('/'),
                child: const Text('/'),
              ),
            ],
          ),
        ],
      ),
    );
  }
}