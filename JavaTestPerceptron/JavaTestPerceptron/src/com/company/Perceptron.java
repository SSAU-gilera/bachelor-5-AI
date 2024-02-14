package com.company;

import java.text.DecimalFormat;

public class Perceptron {

    private static final int BIAS = 5; //Граница разделения на true/false

    double LEARNING_RATE = 0.001; //Скорость обучения
    int NUM_INSTANCES = 100;  // колво тестовых векторов

    int EPOCHS = 50; //Количество эпох обучения

    double[] weights = new double[2]; // 1 вес для переменной и 1 вес для границы

    double localError = 0;
    int errorsCount = 0;

    double[] x = new double [NUM_INSTANCES];
    int[] outputs = new int [NUM_INSTANCES];

    public void call(){
        // вариации, где единиц < нулей
        for(int i = 0; i < NUM_INSTANCES/2; i++){
            x[i] = randomNumber(5 , 10);
            outputs[i] = 1;
        }

        //вариации, где единиц > нулей
        for(int i = 50; i < NUM_INSTANCES; i++){
            x[i] = randomNumber(0 , 4);
            outputs[i] = 0;
        }

        int output;

        weights[0] = randomNumber(0, 1);// вес
        weights[1] = randomNumber(0, 1);// вес границы

        for (int i = 0; i < EPOCHS; i++) {
            for (int p = 0; p < NUM_INSTANCES; p++) {
                output = calculateOutput(weights, x[p]);
                localError = outputs[p] - output; // разница между ожидаемым и поступившим значениями
                weights[0] += LEARNING_RATE * localError * x[p];  //обновляем веса
                weights[1] += LEARNING_RATE * localError;
            }
        }

        for(int j = 0; j < 30; j++){
            double x1 = randomNumber(0 , 10);

            output = calculateOutput(weights, x1);

            String out;
            if(output == 1){
                out = "Единиц больше чем нулей";
            }
            else {
                out = "Единиц меньше чем нулей";
            }

            System.out.println("\n=======\nСлучайный вектор:");
            System.out.println("Количество единиц: " + x1);
            System.out.println("Сеть посчитала: " + out);
        }
        System.out.println("Количество ошибок: " + errorsCount);
    }

    private double randomNumber(int min , int max) {
        DecimalFormat df = new DecimalFormat("#");
        return Double.parseDouble(df.format(min + Math.random() * (max - min)));
    }

    private int calculateOutput(double[] weights, double x) { //сумматор
        double sum = x * weights[0] + weights[1];
        int z = (sum >= BIAS) ? 1 : 0;

        if(x >= 5.0){
            if(z == 0) errorsCount++;
        }
        else{
            if(z == 1) errorsCount++;
        }

        return z;
    }

}
