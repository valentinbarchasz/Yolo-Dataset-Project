import cv2
import numpy as np
import tensorflow as tf
from tensorflow.keras.preprocessing.image import ImageDataGenerator
from tensorflow.keras.applications.mobilenet import preprocess_input
converter = tf.lite.TFLiteConverter.from_saved_model('exported-models/my_model/tflite/saved_model')
converter.optimizations = [tf.lite.Optimize.DEFAULT]

# create an image generator with a batch size of 1 
test_datagen = ImageDataGenerator(preprocessing_function=preprocess_input)
test_generator = test_datagen.flow_from_directory('Temp/test_dataset/val', 
                                                  target_size=(320, 320), 
                                                  batch_size=1, shuffle=False, 
                                                  class_mode='categorical')
                                                  
def represent_data_gen():
    """ it yields an image one by one """
    for ind in range(len(test_generator.filenames)):
        img_with_label = test_generator.next() # it returns (image and label) tuple
        yield [np.array(img_with_label[0], dtype=np.float32, ndmin=2)] # return only image

    
converter.representative_dataset = represent_data_gen
converter.target_spec.supported_ops = [tf.lite.OpsSet.TFLITE_BUILTINS_INT8]
converter.target_spec.supported_types = [tf.int8]
converter.inference_input_type = tf.int8
converter.inference_output_type = tf.int8
tflite_model = converter.convert()

with open('my_model_quantized.tflite', 'wb') as f:
  f.write(tflite_model)