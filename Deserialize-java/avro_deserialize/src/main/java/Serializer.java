import org.apache.avro.file.DataFileWriter;
import org.apache.avro.hadoop.io.AvroSerializer;
import org.apache.avro.mapred.AvroWrapper;
import org.apache.avro.specific.SpecificDatumWriter;
import org.apache.avro.specific.SpecificRecordBase;
import org.apache.tomcat.util.codec.binary.Base64;

import java.io.ByteArrayOutputStream;
import java.io.File;

class Serializer<T extends SpecificRecordBase> {
	public String serialize(T obj) throws Exception {
		// This is the Hadoop AvroSerializer. It's what FindmatchInterface used to use. (As of 11/5/2022 it doesn't)
		// There's also one that I wrote in Resolver that uses SpecificDatumWriter<T>
		AvroSerializer<T> serializer = new AvroSerializer<>(obj.getSchema());
		ByteArrayOutputStream stream = new ByteArrayOutputStream();
		try {
			serializer.open(stream);
			serializer.serialize(new AvroWrapper<>(obj));
			return Base64.encodeBase64String(stream.toByteArray());
		}
		catch (Exception ex) {
			ex.printStackTrace();
		}
		finally {
			serializer.close();
		}
		return null;
	}

	public void serializeToFile(T obj, String fileName) throws Exception {
		SpecificDatumWriter<T> datumWriter = new SpecificDatumWriter<>();
		datumWriter.setSchema(obj.getSchema());

		File outFile = new File(fileName);

		DataFileWriter<T> writer = new DataFileWriter<>(datumWriter);
		writer.create(obj.getSchema(), outFile);
		writer.append(obj);
		writer.close();
	}
}