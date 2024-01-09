export interface BuildExecutorSchema {
  configuration?: 'Debug' | 'Release';
  executeMethod?: string;
  copyTo?: string;
}
