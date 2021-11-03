import tensorflow.compat.v1 as tf

import cv2 
import numpy as np 
from imutils import paths 
def _representative_dataset_gen(): 
    images_path = 'Temp/test_dataset/val'# path to represantative dataset 
    if images_path is None: 
        raise Exception( 
           "Image directory is None, full integer quantization requires images directory!" 
        ) 
    imagePaths = list(paths.list_images(images_path)) 
    for p in imagePaths: 
        image = cv2.imread(p)
        image = cv2.cvtColor(image, cv2.COLOR_BGR2RGB) 
        image = cv2.resize(image, (320, 320)) 
        image = image.astype("float") 
        image = np.expand_dims(image, axis=1) 
        image = image.reshape(1, 320, 320, 3)
        yield [image.astype("float32")]


tflite_model_quant_file = 'exported-models/my_model_Frozen/tflite/saved_model_quantized_8bit.tflite'
saved_model_dir='exported-models/my_model_Frozen/tflite/saved_model'
print(saved_model_dir)
input_arrays = ["normalized_input_image_tensor"] 
output_arrays = ['TFLite_Detection_PostProcess', 
    'TFLite_Detection_PostProcess:1', 
    'TFLite_Detection_PostProcess:2', 
    'TFLite_Detection_PostProcess:3']
input_shapes = {"normalized_input_image_tensor" : [1, 320, 320, 3]} 
converter = tf.lite.TFLiteConverter.from_saved_model(saved_model_dir,input_arrays, 
    output_arrays, input_shapes) 
converter.allow_custom_ops = True 
converter.target_spec.supported_ops = [tf.lite.OpsSet.TFLITE_BUILTINS_INT8]
converter.inference_input_type = tf.int8
# converter.inference_output_type = tf.uint8
converter.experimental_new_quantizer = True
converter.optimizations = [tf.lite.Optimize.DEFAULT] 
converter.representative_dataset = _representative_dataset_gen 
tflite_model_quant = converter.convert() 
with open(tflite_model_quant_file, "wb") as tflite_file: 
    tflite_file.write(tflite_model_quant)